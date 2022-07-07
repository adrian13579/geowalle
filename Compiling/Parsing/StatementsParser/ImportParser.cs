using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;
using Compiling.GObjects;

namespace Compiling.Parsing
{
    public class ImportParser : IStatementParser
    {
        public Statement Parse(Parser parser)
        {
            parser.ConsumeExpectedToken("Import");
            Token token = parser.PreviousParsedToken;
            Constant text = parser.ParseExpression() as Constant;
            Text name = text.Value as Text; 
            parser.ConsumeExpectedToken("StatementSeparator");
            return new ImportStatement(name,token.Location);
        }
        public ImportParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser("Import", this);
        }
    }
}
