using Compiling.GObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class PointDeclaration : GObjectDeclaration
    {
        public PointDeclaration(IdNode name, CodeLocation codeLoc) : base(name, codeLoc)
        {
        }

        public override void Execute(ExecutionScope context,List<CompilingError>errors)
        {
            context.DeclareVariable(Name, new GPoint());
        }
    }
}
