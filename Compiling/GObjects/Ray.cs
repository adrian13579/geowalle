using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Ray : GObject
    {
        public GPoint A { get; }
        public GPoint B { get; }
        public Line Line { get; }
        public Ray(GPoint a, GPoint b)
        {
            A = a;
            B = b;
            Line = new Line(a, b);
        }
        public Ray()
        {
            A = new GPoint();
            B = new GPoint();
        }
        public override string GObjectType()
        {
            return "Ray";
        }
        public override bool IsASequence()
        {
            return false;
        }
    }
}
