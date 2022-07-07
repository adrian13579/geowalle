using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class RestoreStatement : Statement
    {
        public RestoreStatement( CodeLocation codeLoc)
        {
            CodeLocation = codeLoc;
        }

        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
           
        }

        public override void Execute(ExecutionScope context, List<CompilingError> errors)
        {
            context.Drawer.RestoreColor();
        }
    }
}
