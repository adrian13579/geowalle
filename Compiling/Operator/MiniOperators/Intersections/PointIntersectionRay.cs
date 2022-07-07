using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class PointIntersectionRay : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            GPoint point = a as GPoint;
            Ray ray = b as Ray;
            if (Math.Abs(ray.Line.A * point.X + ray.Line.B * point.Y + ray.Line.C) <= 0.001 && Calculus.IsContainedForRay(ray.A, ray.B, point))
            {
                return point;
            }
            List<GObject> seq = new List<GObject>();
            return new Sequence<GObject>(seq, 0);
        }
        public PointIntersectionRay(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Point", "Ray", this);
        }
    }
}
