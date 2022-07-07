using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public abstract class ASTNode
    {
       
        public abstract void CheckSemantics(SemanticScope context,List<CompilingError> errors);
    }
}
