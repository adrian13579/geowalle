using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class GColor : GObject
    {
        public string Color { get; }
        public GColor(string color)
        {
            Color = color;
        }
        public override string GObjectType()
        {
            return "Color";
        }

        public override bool IsASequence()
        {
            return false;
        }
    }
}
