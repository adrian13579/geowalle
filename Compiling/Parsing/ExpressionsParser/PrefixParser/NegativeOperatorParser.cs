using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    class NegativeOperatorParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return 0; 
        }
        public NegativeOperatorParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Token token)
        {
            Expression operand = parser.ParseExpression();
            return new NegativeOperator(operand,token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("Subtract", this);
        }
    }
}
