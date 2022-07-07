using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.Parsing
{
    public class GreenColorParser : ColorParser
    {
        public GreenColorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public override void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser(TokenValues.Green, this);
        }
    }
}
