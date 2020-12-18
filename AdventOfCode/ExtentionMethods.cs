using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class ExtentionMethods
    {
        // Summary:
        //     Copies the characters in this instance to a Unicode character list.
        //
        // Returns:
        //     A Unicode character array whose elements are the individual characters of this
        //     instance.
        public static List<char> ToCharList(this String str)
        {
            return str.ToCharArray().ToList();
        }

        public static IEnumerable<string> SplitAndKeep(this string s, char[] delims)
        {
            int start = 0, index;

            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0)
                    yield return s[start..index];
                yield return s.Substring(index, 1);
                start = index + 1;
            }

            if (start < s.Length)
            {
                yield return s[start..];
            }
        }

        public static double Evaluate(string expression)
        {
                            return (double)new System.Xml.XPath.XPathDocument
                (new StringReader("<r/>")).CreateNavigator().Evaluate
                (string.Format("number({0})", new
                Regex(@"([\+\-\*])")
                .Replace(expression, " ${1} ")
                .Replace("/", " div ")
                .Replace("%", " mod ")));
        }
    }
}
