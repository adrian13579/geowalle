using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class RayDeclarationParser :IStatementParser
    {
        public RayDeclarationParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Statement Parse(Parser parser)
        {
            parser.ConsumeExpectedToken("Ray");
            Token token = parser.PreviousParsedToken;
            VariableCall var = null;
            if (parser.Match("Sequence"))
            {
                var = parser.ParseExpression() as VariableCall;
                parser.ConsumeExpectedToken("StatementSeparator");
                if (var != null)
                    return new PointSequenceDeclaration(var.Name, token.Location);
            }
             var = parser.ParseExpression() as VariableCall;
            parser.ConsumeExpectedToken("StatementSeparator");
            if (var != null)
                return new RayDeclaration(var.Name,token.Location);
            return null;
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser("Ray", this);
        }
    }
}
