using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class LineDeclarationParser : IStatementParser
    {
        public LineDeclarationParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Statement Parse(Parser parser)
        {
            parser.ConsumeExpectedToken("Line");
            Token token = parser.PreviousParsedToken;
            VariableCall var = null;
            if (parser.Match("Sequence"))
            {
                var = parser.ParseExpression() as VariableCall;
                parser.ConsumeExpectedToken("StatementSeparator");
                if (var != null)
                    return new LineSequenceDeclaration(var.Name, token.Location);
            }
             var = parser.ParseExpression() as VariableCall;
            parser.ConsumeExpectedToken("StatementSeparator");
            if (var != null)
                return new LineDeclaration(var.Name,token.Location);
            return null;
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser("Line", this);
        }
    }
}
