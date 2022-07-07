using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    class ThreePointSequenceParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Boolean;
        }
        public ThreePointSequenceParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("{", this);
        }

        public Expression Parse(Parser parser, Token token)
        {
            parser.ConsumeExpectedToken("OpenCurlyBraces");
            Expression left = parser.ParseExpression();
            Expression rigth = null;
            if (parser.LookAhead(0).Value != "ClosedCurlyBraces")
                rigth = parser.ParseExpression();
            parser.ConsumeExpectedToken("ClosedCurlyBraces");
            return new SequenceExpression(new ThreePointsOperator(left, rigth,token.Location));
        }
    }
}
