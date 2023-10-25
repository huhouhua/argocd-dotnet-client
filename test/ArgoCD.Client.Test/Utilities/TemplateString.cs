using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ArgoCD.Client.Test.Utilities
{
    public sealed class TemplateString
    {
        private static readonly Dictionary<string, Func<string>> Templates;

        private static readonly Regex Urldetector;

        public string Original { get; }

        public string Rendered { get; }

        static TemplateString()
        {
            Urldetector = new Regex("((\"|')http(|s)://.*?(\"|'))", RegexOptions.Compiled);
            Templates = new Dictionary<string, Func<string>>
            {
                {
                    "${TMP}",
                    delegate
                    {
                        string text2 = Path.GetTempPath();
                        if (text2.StartsWith("/var/") && FdOs.IsOsx())
                        {

                            text2 =string.Concat("/private/",text2);
                        }
                        return text2.Substring(0, text2.Length - 1);
                    }
                },
                {
                    "${TEMP}",
                    delegate
                    {
                        string text = Path.GetTempPath();
                        if (text.StartsWith("/var/") && FdOs.IsOsx())
                        {
                            text =string.Concat("/private/",text);
                        }
                        return text.Substring(0, text.Length - 1);
                    }
                },
                {
                    "${RND}",
                    Path.GetRandomFileName
                },
                {
                    "${PWD}",
                    Directory.GetCurrentDirectory
                }
            };
        }

        public TemplateString(string str, bool handleWindowsPathIfNeeded = false)
        {
            Original = str;
            Rendered = Render(ToTargetOs(str, handleWindowsPathIfNeeded));
        }

        private static string ToTargetOs(string str, bool handleWindowsPathIfNeeded)
        {
            if (string.IsNullOrEmpty(str) || str.StartsWith("emb:"))
            {
                return str;
            }

            if (!FdOs.IsWindows() || !handleWindowsPathIfNeeded)
            {
                return str;
            }

            Match match = Urldetector.Match(str);
            if (!match.Success)
            {
                return str.Replace('/', '\\');
            }

            var builder = new StringBuilder(match.Index);
            int num = 0;
            while (match.Success)
            {
                builder.Append(str.Substring(num, match.Index - num)).
                    Append(str.Substring(match.Index, match.Length));
                num = match.Index + match.Length;
                match = match.NextMatch();
            }

            builder.Append(str.Substring(num));
            return builder.Replace('/', '\\').ToString();
        }

        private static string Render(string str)
        {
            str = Templates.Keys.Where((string key) => -1 != str.IndexOf(key, StringComparison.Ordinal)).
                Aggregate(str, (string current, string key) => current.Replace(key, Templates[key]()));
            return RenderEnvironment(str);
        }

        private static string RenderEnvironment(string str)
        {
            foreach (DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
            {
                string text = "${E_" + environmentVariable.Key?.ToString() + "}";
                if (-1 != str.IndexOf(text, StringComparison.Ordinal))
                {
                    str = str.Replace(text, (string)environmentVariable.Value);
                }
            }

            return str;
        }

        public static implicit operator TemplateString(string str)
        {
            if (str != null)
            {
                return new TemplateString(str);
            }

            return null;
        }

        public static implicit operator string(TemplateString str) => str?.Rendered;

        public override string ToString()
        {
            return Rendered;
        }
    }



}
