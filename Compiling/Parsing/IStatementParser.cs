using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public interface IStatementParser:IMiniParser
    {
        Statement Parse(Parser parser);
    }
}
