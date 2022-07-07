using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public interface IInfixExpressionParser:IMiniParser
    {
        int GetPrecedence();
        Expression Parse(Parser parser, Expression left, Token token);
    }
}
