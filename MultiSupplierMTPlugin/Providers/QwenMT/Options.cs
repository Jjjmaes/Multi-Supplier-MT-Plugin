using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;

namespace MultiSupplierMTPlugin.Providers.QwenMT
{
    class Options : ProviderOptions
    {
        public Options() : base(new GeneralSettings(), new SecureSettings()) { }

        public Options(GeneralSettings generalOptions, SecureSettings secureOptions) : base(generalOptions, secureOptions) { }
    }

    class GeneralSettings : NMTBaseGeneralSettings
    {
        /// <summary>兼容模式根 URL，不含末尾斜杠，例如 https://dashscope.aliyuncs.com/compatible-mode/v1</summary>
        public string BaseURL { get; set; } = QwenMtEndpoints.Beijing;

        public string Model { get; set; } = "qwen-mt-plus";

        /// <summary>源语言使用 auto，由模型识别（target 仍取自项目语言对）。</summary>
        public bool AutoSourceLanguage { get; set; } = false;

        /// <summary>领域提示，需英文；空则不发送。</summary>
        public string DomainHint { get; set; } = string.Empty;

        /// <summary>将术语表（插件全局术语设置）中匹配的术语对作为 terms 传入。</summary>
        public bool SendGlossaryTerms { get; set; } = true;

        /// <summary>将 memoQ 传入的最佳 TM 句对作为 tm_list 传入。</summary>
        public bool SendTmList { get; set; } = true;

        public double Temperature { get; set; } = 0.65;

        public int MaxTokens { get; set; } = 4096;
    }

    class SecureSettings : NMTBaseSecureSettings
    {
        public string ApiKey { get; set; } = string.Empty;
    }

    static class QwenMtEndpoints
    {
        public const string Beijing = "https://dashscope.aliyuncs.com/compatible-mode/v1";
        public const string Singapore = "https://dashscope-intl.aliyuncs.com/compatible-mode/v1";
        public const string USVirginia = "https://dashscope-us.aliyuncs.com/compatible-mode/v1";
    }
}
