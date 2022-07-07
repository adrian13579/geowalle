using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class ArcSequenceDeclaration : GObjectDeclaration
    {
        public ArcSequenceDeclaration(IdNode name, CodeLocation codeLoc) : base(name, codeLoc)
        {
        }
    }
}
