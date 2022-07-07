using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Undifined : GObject
    {
        public override string GObjectType()
        {
            return "Undifined";
        }
        public override bool IsASequence()
        {
            return false;
        }
    }
}
