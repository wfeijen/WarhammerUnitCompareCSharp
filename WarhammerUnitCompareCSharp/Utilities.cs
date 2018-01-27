using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarhammerUnitCompareCSharp
{
    public class Utilities
    {
        public static int makeZeroIfNotParsedInt(string input)
        {
            int tmp;
            if (int.TryParse(input, out tmp)) return tmp;
            else return 0;
        }

        public static long makeZeroIfNotParsedLong(string input)
        {
            long tmp;
            if (long.TryParse(input, out tmp)) return tmp;
            else return 0;
        }
    }
}

