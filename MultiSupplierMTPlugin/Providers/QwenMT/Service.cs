using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.QwenMT
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private static readonly JsonSerializerSettings JsonIgnoreNull = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }

        public override string UniqueName { get; set; } = ServiceNames.Qwen_MT;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = true;

        public override bool IsHtmlSupported { get; set; } = true;

        public override bool IsBatchSupported { get; set; } = false;

        public override int MaxSegments { get; set; } = 1;

        public override int MaxCharacters { get; set; } = 0;

        public override int MaxQueriesPerWindow { get; set; } = 45;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 50;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://help.aliyun.com/zh/model-studio/get-api-key";

        public override string ApiDocLink { get; set; } = "https://help.aliyun.com/zh/model-studio/machine-translation";

        public override Dictionary<string, string> SupportLangDic { get; set; } = SupportLang.Dic;

        public override ProviderOptions ShowConfig()
        {
            using (var form = new OptionsForm(this, _generalSettings, _secureSettings, _mtGeneralSettings, _mtSecureSettings))
            {
                form.ShowDialog();
            }

            return new Options(_generalSettings, _secureSettings);
        }

        public override async Task<List<string>> TranslateAsync(
            List<string> texts,
            List<string> plainTexts,
            string srcLangCode,
            string trgLangCode,
            List<string> tmSources,
            List<string> tmTargets,
            MTRequestMetadata metaData,
            CancellationToken cToken,
            ProviderOptions tempOptions = null)
        {
            var (g, s) = ResolveOptions(tempOptions);
            var localizedName = ServiceLocalizedNameHelper.Get(UniqueName);

            if (texts == null || texts.Count == 0)
                return new List<string>();

            if (!SupportLangDic.ContainsKey(trgLangCode))
                throw new Exception($"Unsupported target language code: {trgLangCode}");

            string targetLangApi = SupportLangDic[trgLangCode];
            string sourceLangApi = g.AutoSourceLanguage
                ? "auto"
                : (SupportLangDic.ContainsKey(srcLangCode) ? SupportLangDic[srcLangCode] : throw new Exception($"Unsupported source language code: {srcLangCode}"));

            string url = g.BaseURL.TrimEnd('/') + "/chat/completions";

            var results = new List<string>(texts.Count);

            for (int i = 0; i < texts.Count; i++)
            {
                var segmentPlain = i < plainTexts.Count ? plainTexts[i] : texts[i];
                var segmentText = texts[i];

                var translationOptions = new TranslationOptionsBody
                {
                    SourceLang = sourceLangApi,
                    TargetLang = targetLangApi
                };

                if (!string.IsNullOrWhiteSpace(g.DomainHint))
                    translationOptions.Domains = g.DomainHint.Trim();

                if (g.SendGlossaryTerms && _mtGeneralSettings.LLMCommon != null &&
                    !string.IsNullOrWhiteSpace(_mtGeneralSettings.LLMCommon.GlossaryFilePath))
                {
                    var delimiter = _mtGeneralSettings.LLMCommon.GlossaryDelimiter ?? ",";
                    var pairs = GlossaryHelper.ReadGlossaryPairs(
                        new List<string> { segmentPlain },
                        _mtGeneralSettings.LLMCommon.GlossaryFilePath,
                        srcLangCode,
                        trgLangCode,
                        delimiter,
                        "utf-8",
                        true);

                    if (pairs.Count > 0)
                    {
                        translationOptions.Terms = pairs
                            .Select(p => new TermItem { Source = p.Key, Target = p.Value })
                            .ToList();
                    }
                }

                if (g.SendTmList && tmSources != null && tmTargets != null
                    && i < tmSources.Count && i < tmTargets.Count)
                {
                    var tms = tmSources[i];
                    var tmt = tmTargets[i];
                    if (!string.IsNullOrEmpty(tms) && !string.IsNullOrEmpty(tmt))
                    {
                        translationOptions.TmList = new List<TmItem>
                        {
                            new TmItem { Source = tms, Target = tmt }
                        };
                    }
                }

                var request = new QwenMtChatRequest
                {
                    Model = g.Model,
                    Messages = new[]
                    {
                        new ChatMessage { Role = "user", Content = segmentText }
                    },
                    TranslationOptions = translationOptions,
                    Temperature = g.Temperature,
                    MaxTokens = g.MaxTokens > 0 ? g.MaxTokens : (int?)null
                };

                var json = JsonConvert.SerializeObject(request, JsonIgnoreNull);
                LoggingHelper.Info($"{localizedName} Request\r\n{json}");

                var response = await _httpClient
                    .Post(url)
                    .AddHeader("Authorization", "Bearer " + s.ApiKey)
                    .SetBodyJsonString(json)
                    .ReceiveJson<QwenMtChatResponse>(cToken);

                var choice = response?.Choices?[0];
                var content = choice?.Message?.Content;
                if (string.IsNullOrEmpty(content))
                    throw new Exception($"{localizedName} empty response content");

                LoggingHelper.Info($"{localizedName} Response\r\n{content}");
                results.Add(content);
            }

            return results;
        }
    }
}
