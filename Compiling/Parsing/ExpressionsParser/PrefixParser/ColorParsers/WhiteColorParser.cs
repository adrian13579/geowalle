using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.Parsing
{
    public class WhiteColorParser : ColorParser
    {
        public WhiteColorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public override void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser(TokenValues.White, this);
        }
    }
}
