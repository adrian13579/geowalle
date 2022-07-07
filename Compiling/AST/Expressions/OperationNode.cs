using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public abstract class OperationNode : Expression
    {
        public abstract string OperationIdentifier();
    }
}
