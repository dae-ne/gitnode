using System.Linq;
using System.Text.RegularExpressions;

namespace GitNode.WebApi.Extensions
{
    internal static class StringExtensions
    {
        public static string ToSnakeCase(this string text)
        {
            return string
                .Concat(text.Select((c, i) => i > 0 && char.IsUpper(c) ? "_" + c : c.ToString()))
                .ToLower();
        }
        
        public static string ToHyphenCase(this string text)
        {
            return Regex.Replace(
                text, 
                "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", 
                "-$1",
                RegexOptions.Compiled)
                .Trim()
                .ToLower();
        }
    }
}