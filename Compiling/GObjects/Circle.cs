using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Circle : GObject
    {
        public double Radius { get; }
        public GPoint Center { get; }
        public Circle(GPoint center ,Measure radius)
        {
            Center = center;
            Radius = radius.Value;
        }
        public Circle(GPoint center,Number radius)
        {
            Center = center;
            Radius = radius.Value;
        }
        public Circle()
        {
            Random r = new Random();
            Center = new GPoint();
            Radius = r.NextDouble() * 100;
        }

        public override string GObjectType()
        {
            return "Circle";
        }

        public override bool IsASequence()
        {
            return false;
        }
    }
}
