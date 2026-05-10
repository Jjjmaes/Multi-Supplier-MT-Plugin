using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.QwenMT
{
    class LocalizedKey : LocalizedKeyBase
    {
        public LocalizedKey(string name) : base(name)
        {
        }

        static LocalizedKey()
        {
            AutoInit<LocalizedKey>();
        }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000001", "Qwen-MT (DashScope)", "通义 Qwen-MT")]
        public static LocalizedKey FormTitle { get; private set; }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000002", "API Key (DashScope)", "API Key（百炼）")]
        public static LocalizedKey LinkLabelApiKey { get; private set; }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000003", "Region / Base URL", "地域 / 服务地址")]
        public static LocalizedKey LabelRegion { get; private set; }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000004", "Custom base URL", "自定义 Base URL")]
        public static LocalizedKey LabelCustomUrl { get; private set; }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000005", "Model", "模型")]
        public static LocalizedKey LabelModel { get; private set; }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000006", "Auto-detect source language (source_lang=auto)", "自动识别源语言（source_lang=auto）")]
        public static LocalizedKey CheckAutoSource { get; private set; }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000007", "Domain hint (English, optional)", "领域提示（英文，可选）")]
        public static LocalizedKey LabelDomain { get; private set; }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000008", "Send matched glossary terms (terms)", "发送术语表匹配项（terms）")]
        public static LocalizedKey CheckGlossary { get; private set; }

        [LocalizedValue("b2f9d5e1-6c4a-5e8f-a901-100000000009", "Send best TM pair (tm_list)", "发送最佳翻译记忆句对（tm_list）")]
        public static LocalizedKey CheckTm { get; private set; }
    }
}
