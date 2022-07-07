using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class EqualsOperatorParser : IInfixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Boolean;
        }
        public EqualsOperatorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Expression left, Token token)
        {
            Expression right = parser.ParseExpression(GetPrecedence());
            return new EqualsOperator(left, right, token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterInfixParser("Equals", this);
        }
    }
}
