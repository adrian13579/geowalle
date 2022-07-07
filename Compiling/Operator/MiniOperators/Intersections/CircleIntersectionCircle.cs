using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class CircleIntersectionCircle : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Circle c1 = a as Circle;
            Circle c2 = b as Circle;
            List<GPoint> intersect = new List<GPoint>();
            double x1 = c1.Center.X;
            double y1 = c1.Center.Y;
            double x2 = c2.Center.X;
            double y2 = c2.Center.Y;
            double r1 = c1.Radius;
            double r2 = c2.Radius;

            double v = (2 * x2) - (2 * x1);
            double w = (2 * y2) - (2 * y1);
            double z = (x1 * x1) + (y1 * y1) - (x2 * x2) - (y2 * y2) + (r2 * r2) - (r1 * r1);

            double a1 = ((w * w) / (v * v)) + 1;
            double a2 = ((2 * w * z) / (v * v)) + ((2 * x1 * w) / v) - (2 * y1);
            double a3 = (x1 * x1) + (y1 * y1) + ((z * z) / (v * v)) + ((2 * x1 * z) / v) - (r1 * r1);

            double discriminant = (a2 * a2) - 4 * a1 * a3;
            if (discriminant > 0)
            {
                double y0 = (((-1 * a2) + (Math.Sqrt(discriminant))) / (2 * a1));

                double y = (((-1 * a2) - (Math.Sqrt(discriminant))) / (2 * a1));

                double x0 = ((-w * y0) - z) / v;

                double x = ((-w * y) - z) / v;


                intersect.Add(new GPoint(x0, y0));


                intersect.Add(new GPoint(x, y));
            }
            else if (discriminant == 0)
            {

                double y0 = -a2 + (Math.Sqrt(discriminant) / (2 * a1));

                double x0 = ((-w * y0) - z) / v;

                intersect.Add(new GPoint(x0, y0));
            }
            return new Sequence<GObject>(intersect,intersect.Count);
        }
        public CircleIntersectionCircle(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Circle", "Circle",this);
        }
    }
}
