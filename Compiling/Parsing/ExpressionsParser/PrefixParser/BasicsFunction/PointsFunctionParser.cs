using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class PointsFunctionParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Call;
        }

        public Expression Parse(Parser parser, Token token)
        {
            parser.ConsumeExpectedToken("OpenBracket");
            Expression a = parser.ParseExpression();
            parser.ConsumeExpectedToken("ClosedBracket");
            return new PointsFunction(a,token.Location);
        }
        public PointsFunctionParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("points", this);
        }
    }
}
