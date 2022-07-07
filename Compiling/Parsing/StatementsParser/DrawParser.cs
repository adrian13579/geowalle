using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class DrawParser :IStatementParser
    {
        public DrawParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Statement Parse(Parser parser)
        {
            parser.ConsumeExpectedToken("Draw");
            Token token = parser.PreviousParsedToken;
            Expression rigth = parser.ParseExpression();
            Expression label = null;
            Token lookAhead = parser.LookAhead(0);
            if (lookAhead!=null && lookAhead.Type==TokenType.Text)
            {
                label = parser.ParseExpression();
            }
            parser.ConsumeExpectedToken("StatementSeparator");
            return new DrawStatement(rigth,label,token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser("Draw", this);
        }
    }
}
