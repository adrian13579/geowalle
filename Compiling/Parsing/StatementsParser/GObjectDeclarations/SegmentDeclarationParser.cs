using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class SegmentDeclarationParser : IStatementParser
    {
        public SegmentDeclarationParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Statement Parse(Parser parser)
        {
            parser.ConsumeExpectedToken("Segment");
            Token token = parser.PreviousParsedToken;
            VariableCall var = null;
            if (parser.Match("Sequence"))
            {
                var = parser.ParseExpression() as VariableCall;
                parser.ConsumeExpectedToken("StatementSeparator");
                if (var != null)
                    return new ArcSequenceDeclaration(var.Name, token.Location);
            }
             var = parser.ParseExpression() as VariableCall;
            parser.ConsumeExpectedToken("StatementSeparator");
            if (var != null)
                return new SegmentDeclaration(var.Name,token.Location);
            return null;
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser("Segment", this);
        }
    }
}
