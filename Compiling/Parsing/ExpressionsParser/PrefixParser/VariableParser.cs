using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class VariableParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return 0;
        }
        public VariableParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Token token)
        {
            return new VariableCall(new IdNode(token.Value),token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser(TokenType.Identifier, this);
            parser.RegisterPrefixParser("Underscore", this);
        }
    }
}
