using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;
using Compiling.GObjects;

namespace Compiling.Parsing
{
    public class TextParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return 0;
        }
        public Expression Parse(Parser parser, Token token)
        {
            return new Constant(new Text(token.Value),token.Location);
        }
        public TextParser(Parser parser )
        {
            SelfRegister(parser);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser(TokenType.Text, this);
        }
    }
}
