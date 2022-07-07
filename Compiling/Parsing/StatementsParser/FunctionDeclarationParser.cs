using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class FunctionDeclarationParser : IDeclarationParser
    {
       
        public Statement Parse(Parser parser)
        {
            FunctionCall function = parser.ParseExpression() as FunctionCall;
            Token token = parser.PreviousParsedToken;
            parser.ConsumeExpectedToken("Assign");
            Expression body = parser.ParseExpression();
            parser.ConsumeExpectedToken("StatementSeparator");
            if (function == null)
            {
                parser.Errors.Add(new CompilingError(token.Location, ErrorCode.Unknown, "Error al parsear la funcion"));
                return null;
            }
            return new FunctionDeclaration(function.Name, ConvertToIdNode(function.Args), body,token.Location);
        }

        public FunctionDeclarationParser(DeclarationParser parser)
        {
            SelfRegister(parser);
        }
        public void SelfRegister(DeclarationParser decParser)
        {
            decParser.Register("OpenBracket", this);
        }

        private List<IdNode> ConvertToIdNode(List<Expression> variables)
        {
            List<IdNode> result = new List<IdNode>();
            foreach (var item in variables)
            {
                VariableCall temp = item as VariableCall;
                result.Add(temp.Name);
            }
            return result;
        }
    }
}
