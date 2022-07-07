using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class LineIntersectionCircle : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            List<GPoint> result = new List<GPoint>();
            Circle c1 = b as Circle;
            Line l1 = a as Line;
            double x = c1.Center.X;
            double y = c1.Center.Y;
            double rad = c1.Radius;
            double aux1 = ((l1.B * l1.B) / (l1.A * l1.A)) + 1;
            double aux2 = (((2 * l1.B * l1.C) / (l1.A * l1.A)) + ((2 * l1.B * x) / l1.A) - 2 * y);
            double aux3 = (((l1.C * l1.C) / (l1.A * l1.A)) + ((2 * x * l1.C) / l1.A) + (x * x) + (y * y) - (rad * rad));

            double discriminant = (aux2 * aux2) - (4 * (aux1 * aux3));
            if (discriminant > 0)
            {
                double y1 = ((-aux2) - Math.Sqrt(discriminant)) / (2 * aux1);

                double y2 = ((-aux2) + Math.Sqrt(discriminant)) / (2 * aux1);

                double x1 = (-l1.B * y1 - l1.C) / l1.A;

                double x2 = (-l1.B * y2 - l1.C) / l1.A;

                result.Add(new GPoint(x1, y1));
                result.Add(new GPoint(x2, y2));
            }
            if (discriminant == 0)
            {
                double y1 = ((-aux2) - Math.Sqrt(discriminant)) / (2 * aux1);
                double x1 = (-l1.B * y1 - l1.C) / l1.A;
                result.Add(new GPoint(x1, y1));
            }
            return new Sequence<GObject>( result,result.Count);
        }

        public LineIntersectionCircle(Operator op )
        {
            SelfRegister(op);
        }
        public LineIntersectionCircle()
        {

        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Line", "Circle", this);
        }
    }
}
