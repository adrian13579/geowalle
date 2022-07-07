using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class LineIntersectionLine : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Line lineA = a as Line;
            Line lineB = b as Line;
            if (lineA.A == lineB.A && lineA.B == lineB.B && lineA.C == lineB.C)
                return new Undifined();
            List<GPoint> intersect = new List<GPoint>();
            double x = 0;
            double y = 0;
            if (lineA.A == lineB.A && lineA.B == lineB.B && lineA.C == lineB.C) { return null; }
            else if (lineA.B != 0 && lineB.B != 0)
            {
                if (lineA.Slope() == lineB.Slope())
                {
                    if (lineA.IntersectY() == lineB.IntersectY()) { return null; }
                }
                else
                {
                    x = (lineB.IntersectY() - lineA.IntersectY()) / (lineA.Slope() - lineB.Slope());
                    y = lineA.Slope() * x + lineA.IntersectY();

                    intersect.Add(new GPoint((int)x, (int)y));
                }
            }
            else if (lineA.B == 0 && lineB.B != 0)
            {
                y = (-lineB.A * (-lineA.C / lineA.A) - lineB.C) /lineB.B;
                x = (-lineB.B - lineB.C) / lineB.B;
            }
            else if (lineA.B != 0 && lineB.B == 0)
            {
                y = (-lineA.A * (-lineB.C / lineB.A) - lineA.C) / lineA.B;
                x = (-lineA.B - lineA.C) / lineA.B;
            }
            return new Sequence<GObject>(intersect,intersect.Count);
        }
        public LineIntersectionLine(Operator  op)
        {
            SelfRegister(op);
        }
        public LineIntersectionLine()
        {

        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Line", "Line", this);
        }
    }
}
