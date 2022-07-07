using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class PointIntersectionSegment : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            GPoint point = a as GPoint;
            Segment seg = b as Segment;
            if (Math.Abs(seg.Line.A * point.X + seg.Line.B * point.Y + seg.Line.C) <= 0.001 && Calculus.IsContainedForSegment(seg.A,seg.B,point))
            {
                return point;
            }
            List<GObject> seq = new List<GObject>();
            return new Sequence<GObject>(seq, 0);
        }
        public PointIntersectionSegment(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Point", "Segment", this);
        }
    }
}
