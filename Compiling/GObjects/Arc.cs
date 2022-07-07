using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Arc : GObject
    {
        public GPoint Center { get; }
        public GPoint A { get; }
        public GPoint B { get; }
        public Measure Length { get; }
        public Arc()
        {

        }
        public override string GObjectType()
        {
            return "Arc";
        }

        public override bool IsASequence()
        {
            return false;
        }
    }
}
