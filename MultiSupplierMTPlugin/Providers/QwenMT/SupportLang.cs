using MultiSupplierMTPlugin.ProvidersCommon.SupportLanguages;
using System;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.QwenMT
{
    static class SupportLang
    {
        /// <summary>
        /// Qwen-MT 使用语言英文全称；由 memoQ 三字母码映射为文档要求的名称（去掉地区括号后缀）。
        /// </summary>
        public static readonly Dictionary<string, string> Dic = BuildDic();

        private static Dictionary<string, string> BuildDic()
        {
            var d = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kv in LLM.Dic)
            {
                d[kv.Key] = MemoQLangToQwenApiName(kv.Value);
            }
            return d;
        }

        internal static string MemoQLangToQwenApiName(string memoqEnglishDisplayName)
        {
            if (string.IsNullOrEmpty(memoqEnglishDisplayName))
                return memoqEnglishDisplayName;

            var i = memoqEnglishDisplayName.IndexOf('(');
            if (i > 0)
                return memoqEnglishDisplayName.Substring(0, i).Trim();

            return memoqEnglishDisplayName.Trim();
        }
    }
}
