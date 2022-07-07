using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class ThreePointOperatorParser : IInfixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Boolean;
        }
        public ThreePointOperatorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Expression left, Token token)
        {
            Expression rigth = null;
            parser.ConsumeExpectedToken(".");
            parser.ConsumeExpectedToken(".");
            if (parser.LookAhead(0).Value != "ClosedCurlyBracket")
                rigth = parser.ParseExpression(GetPrecedence());
            return new ThreePointsOperator(left, rigth, token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterInfixParser(".", this);
        }
    }
}
