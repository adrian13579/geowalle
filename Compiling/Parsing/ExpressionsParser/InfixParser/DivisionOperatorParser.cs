using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class DivisionOperatorParser : IInfixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Multiplication;
        }
        public DivisionOperatorParser(Parser parser)
        {
            SelfRegister(parser);
        }

        public Expression Parse(Parser parser, Expression left, Token token)
        {
            Expression right = parser.ParseExpression(GetPrecedence());
            return new DivisionOperator(left, right, token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterInfixParser("Division", this);
        }
    }
}
