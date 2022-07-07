using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class NotOperatorParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return 0;
        }

        public Expression Parse(Parser parser, Token token)
        {
            Expression exp = parser.ParseExpression();
            return new NotOperator(exp,token.Location);
        }
        public NotOperatorParser(Parser parser)
        {
            SelfRegister(parser);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("Not", this);
        }
    }
}
