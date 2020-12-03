using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
