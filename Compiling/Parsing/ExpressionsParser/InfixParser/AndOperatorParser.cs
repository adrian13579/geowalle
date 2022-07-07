using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class AndOperatorParser : IInfixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.And;
        }

        public Expression Parse(Parser parser, Expression left, Token token)
        {
            Expression right = parser.ParseExpression(GetPrecedence());
            return new AndOperator(left, right,token.Location);
        }
        public AndOperatorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public void SelfRegister(Parser parser)
        {
            parser.RegisterInfixParser("And", this);
        }
    }
}
