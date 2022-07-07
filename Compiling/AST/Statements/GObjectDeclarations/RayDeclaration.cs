using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class RayDeclaration : GObjectDeclaration
    {
        public RayDeclaration(IdNode name, CodeLocation codeLoc) : base(name, codeLoc)
        {
        }

        public override void Execute(ExecutionScope context,List<CompilingError>errors)
        {
            context.DeclareVariable(Name, new Ray());
        }
    }
}
