using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class PointIntersectionLine : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }
        public GObject Operate(GObject a, GObject b)
        {
            GPoint point = a as GPoint;
            Line line = b as Line;
            if (Math.Abs(line.A*point.X+line.B*point.Y+line.C)<=0.001 )
            {
                return point;
            }
            List<GObject> seq = new List<GObject>();
            return new Sequence<GObject>(seq, 0);
        }
        public PointIntersectionLine(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Point", "Line", this);
        }
    }
}
