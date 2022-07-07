using Compiling.GObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public abstract class Expression : ASTNode
    {
        public CodeLocation CodeLocation { get; set; }
        public abstract GObject EvaluateOn(ExecutionScope memory, List<CompilingError> errors);
    }
}
