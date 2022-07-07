using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Measure : GObject
    {
        public double Value { get; }
        public Measure(GPoint a,GPoint b)
        {
            Value=Math.Sqrt(Math.Pow((a.X-b.X),2)+ Math.Pow((a.Y - b.Y), 2));
        }
        public Measure(double a)
        {
            Value = Math.Abs(a);
        }
        public override string GObjectType()
        {
            return "Measure";
        }
        public override bool IsASequence()
        {
            return false;
        }
    }
}
