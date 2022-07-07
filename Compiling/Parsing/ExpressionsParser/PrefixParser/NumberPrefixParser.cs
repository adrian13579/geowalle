using Compiling.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Parsing
{
    public class NumberPrefixParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return 0;
        }
        public NumberPrefixParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Token token)
        {
            double value;
            if (double.TryParse(token.Value, out value)) ;
            else
            {
                value = double.NegativeInfinity;
                parser.Errors.Add(new CompilingError(token.Location, ErrorCode.Unknown, "No se reconoce la expression"));
            }
            return new Constant(new Number(value),token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser(TokenType.Number, this);
        }
    }
}
