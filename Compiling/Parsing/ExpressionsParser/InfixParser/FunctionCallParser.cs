using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class FunctionCallParser : IInfixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Call;
        }
        public FunctionCallParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Expression left, Token token)
        {
            FunctionCall result = null;
            List<Expression> args = new List<Expression>();
            if (!parser.Match("ClosedBracket"))
            {
                do
                {
                    args.Add( parser.ParseExpression());
                } while (parser.Match("ValueSeparator"));
                parser.ConsumeExpectedToken("ClosedBracket");
            }
            VariableCall varName = left as VariableCall;
            if (varName == null)
            {
                parser.Errors.Add(new CompilingError(parser.PreviousParsedToken.Location, ErrorCode.Expected, "The left-hand side of a function  must be a name."));
            }
            else result= new FunctionCall(varName.Name, args, token.Location);
            return result;
        }

        public void SelfRegister(Parser parser)
        {
           parser.RegisterInfixParser("OpenBracket",this); 
        }
       
    }
}
