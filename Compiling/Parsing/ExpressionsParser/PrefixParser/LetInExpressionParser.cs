using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class LetInExpressionParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
          return   Precedence.ConditionalClausule;
        }
        public LetInExpressionParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public Expression Parse(Parser parser, Token token)
        {
            List<Statement> instructions = new List<Statement>();
            do
            {
                instructions.Add(parser.ParseStatement());
            } while (!parser.Match("InClausule"));
            Expression inExpresion = parser.ParseExpression(GetPrecedence());
            return new LetInExpresison(instructions, inExpresion,token.Location);
        }

        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("LetClausule", this);
        }
    }
}
