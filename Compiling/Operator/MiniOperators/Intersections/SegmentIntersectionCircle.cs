using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class SegmentIntersectionCircle : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Segment seg = a as Segment;
            Circle circle = b as Circle;
            IBinaryOperator lineIntersectCircle = new LineIntersectionCircle();
            List<GObject> intersect = new List<GObject>();
            
            Sequence<GObject> lineLineIntersect = lineIntersectCircle.Operate(seg.Line, circle) as Sequence<GObject>;
            if (lineLineIntersect == null)
                return new Undifined();

            foreach (var item in lineLineIntersect.Items)
            {
                var C = item as GPoint;
                if (Calculus.IsContainedForSegment(seg.A, seg.B, C))
                    intersect.Add(C);
            }
            return new Sequence<GObject>(intersect, intersect.Count);
        }
        
        public SegmentIntersectionCircle(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Segment", "Circle", this);
        }
    }
}
