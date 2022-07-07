using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public abstract class Statement : ASTNode
    {
        public CodeLocation CodeLocation { get; set; }
        public abstract void Execute(ExecutionScope context, List<CompilingError> errors); 
    }
    
}
