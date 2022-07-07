using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class IntersectParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Call;
        }

        public Expression Parse(Parser parser, Token token)
        {
            parser.ConsumeExpectedToken("OpenBracket");
            Expression a = parser.ParseExpression();
            parser.ConsumeExpectedToken("ValueSeparator");
            Expression b = parser.ParseExpression();
            parser.ConsumeExpectedToken("ClosedBracket");
            return new Intersect(a, b, token.Location);
        }
        public IntersectParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("intersect", this);
        }
    }
}
