using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Join
{
    public static class StringExtensions
    {
        public static string Join(this IEnumerable<string> self, string seperator)
        {
            return string.Join(seperator, self);
        }

        public static bool IsEqualIgnoreCase(this string source, string target)
        {
            return string.Equals(source, target, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
