using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class RestoreParser : IStatementParser
    {
        public Statement Parse(Parser parser)
        {
            parser.ConsumeExpectedToken("Restore");
            Token token = parser.PreviousParsedToken;
            parser.ConsumeExpectedToken("StatementSeparator");
            return new RestoreStatement(token.Location);
        }
        public RestoreParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser("Restore", this);
        }
    }
}
