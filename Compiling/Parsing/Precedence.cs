using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.Parsing
{
    public static class Precedence
    {
        public static int And = 5;
        public static int Boolean = 10;
        public static int Addition = 50;
        public static int Multiplication = 100;
        public static int Call = 150;
        public static int ConditionalClausule = 150;
    }
}
