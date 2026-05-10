using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.QwenMT
{
    class QwenMtChatRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("messages")]
        public ChatMessage[] Messages { get; set; }

        [JsonProperty("translation_options")]
        public TranslationOptionsBody TranslationOptions { get; set; }

        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        public double? Temperature { get; set; }

        [JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxTokens { get; set; }
    }

    class ChatMessage
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    class TranslationOptionsBody
    {
        [JsonProperty("source_lang")]
        public string SourceLang { get; set; }

        [JsonProperty("target_lang")]
        public string TargetLang { get; set; }

        [JsonProperty("terms", NullValueHandling = NullValueHandling.Ignore)]
        public List<TermItem> Terms { get; set; }

        [JsonProperty("tm_list", NullValueHandling = NullValueHandling.Ignore)]
        public List<TmItem> TmList { get; set; }

        [JsonProperty("domains", NullValueHandling = NullValueHandling.Ignore)]
        public string Domains { get; set; }
    }

    class TermItem
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }

    class TmItem
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }

    class QwenMtChatResponse
    {
        [JsonProperty("choices")]
        public QwenChoice[] Choices { get; set; }
    }

    class QwenChoice
    {
        [JsonProperty("message")]
        public QwenChoiceMessage Message { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }
    }

    class QwenChoiceMessage
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
