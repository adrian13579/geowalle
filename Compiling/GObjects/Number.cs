using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Number : GObject
    { 
        public double Value { get; set; }

        public Number(double value)
        {
            Value = value;
        }

        public override string GObjectType()
        {
            return "Number";
        }
        public override bool IsASequence()
        {
            return false;
        }
    }
}
