using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class RayConstructorParser : ConstructorsParser
    {
        public RayConstructorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public override ConstructorExpression ReturnCurrentGObject(List<Expression> args,Token token)
        {
            return new RayConstructor(args,token.Location);
        }

        public override void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("Ray", this);
        }
    }
}
