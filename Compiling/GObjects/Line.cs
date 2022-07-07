using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Line : GObject
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public GPoint PointA { get; }
        public GPoint PointB { get; }
        public Line(GPoint a, GPoint b)
        {
            PointA = a;
            PointB = b;
            if (a.X == b.X)
            {
                A = 1;
                B = 0;
                C = -a.X;
            }
            else
            {
                A = -(a.Y - b.Y) / (a.X - b.X);
                B = 1;
                C = -(A * a.X) - a.Y;
            }
        }
        public double IntersectY()
        {
            return -C / B;
        }
        public double Slope()
        {
            return -A / B;
        }
        public override string GObjectType()
        {
            return "Line";
        }
        public override bool IsASequence()
        {
            return false;
        }
    }
}
