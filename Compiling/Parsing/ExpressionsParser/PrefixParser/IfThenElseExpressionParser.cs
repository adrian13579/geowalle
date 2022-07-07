using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class IfThenElseExpressionParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.ConditionalClausule;
        }
        public IfThenElseExpressionParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Token token)
        {
            Expression conditional = parser.ParseExpression();
            parser.ConsumeExpectedToken("ThenClausule");
            Expression thenContent = parser.ParseExpression();
            parser.ConsumeExpectedToken("ElseClausule");
            Expression elseContent = parser.ParseExpression();
            return new IfThenElseExpression(conditional, thenContent, elseContent,token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("IfClausule", this);
        }
    }
}
