using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class VariablesDeclarationParser : IDeclarationParser
    {
        public VariablesDeclarationParser(DeclarationParser parser)
        {
            SelfRegister(parser);
        }
        public Statement Parse(Parser parser)
        {
            List<VariableCall> variables = new List<VariableCall>();
            Token token;
            do
            {
                VariableCall var= parser.ParseExpression() as VariableCall;
                 token = parser.PreviousParsedToken;
                if (var != null)
                {
                    variables.Add(var);
                }
                else
                {
                    parser.Errors.Add(new CompilingError(token.Location, ErrorCode.Invalid, "Se espera una variable"));
                   parser.ReStartParsingTo(token);
                }    
            } while (parser.Match("ValueSeparator"));
            parser.ConsumeExpectedToken("Assign");
            Expression expression = parser.ParseExpression();
            parser.ConsumeExpectedToken("StatementSeparator");
            return new VariablesDeclaration(ConvertToIdNode(variables), expression, token.Location);
        }


        public void SelfRegister(DeclarationParser decParser)
        {
            decParser.Register("ValueSeparator", this);
            decParser.Register("Assign", this);
            
        }

        private List<IdNode> ConvertToIdNode(List<VariableCall> variables)
        {
            List<IdNode> result = new List<IdNode>();
            foreach (var item in variables)
            {
                result.Add(item.Name);
            }
            return result;
        }
    }
}
