using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class SequenceExpressionParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return 0;
        }
        public SequenceExpressionParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Token token)
        {
            List<Expression> items = new List<Expression>();
            Expression item;
            if (!parser.Match("ClosedCurlyBraces"))
            {
                item = parser.ParseExpression();
                if(item is ThreePointsOperator)
                {
                    parser.ConsumeExpectedToken("ClosedCurlyBraces");
                    parser.ConsumeExpectedToken("StatementSeparator");
                    return new SequenceExpression(item);
                }
                items.Add(item);
                parser.Match("ValueSeparator");
                do
                {
                    item = parser.ParseExpression();
                    if(item == null)
                    {
                        parser.Errors.Add(new CompilingError(parser.PreviousParsedToken.Location, ErrorCode.Unknown, "No se pudo parsear un elemento de la secuencia"));
                        continue;
                    }
                    items.Add(item);
                } while (parser.Match("ValueSeparator"));
            }
            parser.ConsumeExpectedToken("ClosedCurlyBraces");
            return new SequenceExpression(items,token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("OpenCurlyBraces", this);
        }
    }
}
