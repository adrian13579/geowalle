using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    class ColorStatementParser : IStatementParser
    {
        public ColorStatementParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Statement Parse(Parser parser)
        {
            parser.ConsumeExpectedToken("Color");
            Token token = parser.PreviousParsedToken;
            Expression color = parser.ParseExpression();
            parser.ConsumeExpectedToken("StatementSeparator");
            return new ColorStatement(color,token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser(TokenValues.Color, this);
        }
    }
}
