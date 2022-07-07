using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    class CircleDeclarationParser : IStatementParser
    {
        public CircleDeclarationParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Statement Parse(Parser parser)
        {
            parser.ConsumeExpectedToken("Circle");
            Token token = parser.PreviousParsedToken;
            VariableCall var = null;
            if (parser.Match("Sequence"))
            {
                var = parser.ParseExpression() as VariableCall;
                parser.ConsumeExpectedToken("StatementSeparator");
                if (var != null)
                    return new CircleSequenceDeclaration(var.Name, token.Location);
            }
            var = parser.ParseExpression() as VariableCall;
            parser.ConsumeExpectedToken("StatementSeparator");
            if (var != null)
                return new CircleDeclaration(var.Name,token.Location);
            return null;
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser("Circle", this);
        }
    }
}
