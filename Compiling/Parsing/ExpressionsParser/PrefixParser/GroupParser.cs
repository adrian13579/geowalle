using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class GroupParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return 0;
        }
        public GroupParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Token token)
        {
            Expression innerExpression = parser.ParseExpression();
            parser.ConsumeExpectedToken("ClosedBracket");
            return innerExpression;
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("OpenBracket", this);
        }
    }
}
