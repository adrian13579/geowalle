using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class SegmentIntersectionRay : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Segment seg = a as Segment;
            Ray ray = b as Ray;
            IBinaryOperator lineIntersectLine = new LineIntersectionLine();
            List<GObject> intersect = new List<GObject>();

            Sequence<GObject> lineLineIntersect = lineIntersectLine.Operate(seg.Line, ray.Line) as Sequence<GObject>;
            if (lineLineIntersect == null)
                return new Undifined();

            foreach (var item in lineLineIntersect.Items)
            {
                var C = item as GPoint;
                if (Calculus.IsContainedForSegment(seg.A, seg.B, C) && Calculus.IsContainedForRay(ray.A,ray.B,C) )
                    intersect.Add(C);
            }
            return new Sequence<GObject>(intersect, intersect.Count);
        }
        public SegmentIntersectionRay(Operator op)
        {
            SelfRegister(op);
        }
      
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Segment", "Ray", this);
        }
    }
}
