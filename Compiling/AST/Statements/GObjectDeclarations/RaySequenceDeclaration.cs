using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class RaySequenceDeclaration : GObjectDeclaration
    {
        public RaySequenceDeclaration(IdNode name, CodeLocation codeLoc) : base(name, codeLoc)
        {
        }
    }
}
