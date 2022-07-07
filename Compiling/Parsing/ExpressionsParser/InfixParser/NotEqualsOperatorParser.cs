using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    class NotEqualsOperatorParser : IInfixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Boolean;
        }
        public NotEqualsOperatorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Expression left, Token token)
        {
            Expression right = parser.ParseExpression(GetPrecedence());
            return new NotEqualsOperator(left, right, token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterInfixParser("NotEquals", this);
        }
    }
}
