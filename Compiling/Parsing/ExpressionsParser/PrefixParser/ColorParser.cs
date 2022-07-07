using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;
using Compiling.GObjects;

namespace Compiling.Parsing
{
    public  abstract class ColorParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return 0;
        }

        public Expression Parse(Parser parser, Token token)
        {
            return new Constant(new GColor(token.Value),token.Location);
        }

        public abstract void SelfRegister(Parser parser);
    }
}
