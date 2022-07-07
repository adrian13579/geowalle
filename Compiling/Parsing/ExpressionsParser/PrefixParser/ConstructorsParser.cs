using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;


namespace Compiling.Parsing
{
    public abstract class ConstructorsParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Call;
        }

        public Expression Parse(Parser parser, Token token)
        {
            List<Expression> args = new List<Expression>();
            parser.ConsumeExpectedToken("OpenBracket");
            do
            {
                args.Add(parser.ParseExpression());
            } while (parser.Match("ValueSeparator"));
            parser.ConsumeExpectedToken("ClosedBracket");
            return ReturnCurrentGObject(args,token);
        }
        public abstract ConstructorExpression ReturnCurrentGObject(List<Expression> args,Token token);

        public abstract void SelfRegister(Parser parser);
    }
}
