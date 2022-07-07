using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class PointIntersectionCircle : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            GPoint point = a as GPoint;
            Circle circle = b as Circle;
            if (Math.Abs(Math.Pow(point.X-circle.Center.X,2)+Math.Pow(point.Y-circle.Center.Y,2))<=0.001)
            {
                return point;
            }
            List<GObject> seq = new List<GObject>();
            return new Sequence<GObject>(seq, 0);
        }
        public PointIntersectionCircle(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Point", "Circle", this);
        }
    }
}
