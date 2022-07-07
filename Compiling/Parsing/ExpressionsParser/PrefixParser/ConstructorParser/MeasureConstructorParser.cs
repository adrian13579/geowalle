using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class MeasureConstructorParser : ConstructorsParser
    {
        public override ConstructorExpression ReturnCurrentGObject(List<Expression> args,Token token)
        {
            return new MeasureConstructor(args,token.Location);
        }
        public MeasureConstructorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public override void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser(TokenValues.Measure, this);
        }
    }
}
