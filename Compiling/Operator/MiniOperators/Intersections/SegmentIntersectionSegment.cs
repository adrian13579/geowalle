using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class SegmentIntersectionSegment : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Segment segA = a as Segment;
            Segment segB = b as Segment;
            IBinaryOperator lineIntersectLine = new LineIntersectionLine();
            List<GObject> intersect = new List<GObject>();

            Sequence<GObject> lineLineIntersect = lineIntersectLine.Operate(segA.Line, segB.Line) as Sequence<GObject>;
            if (lineLineIntersect == null)
                return new Undifined();

            foreach (var item in lineLineIntersect.Items)
            {
                var C = item as GPoint;
                if (Calculus.IsContainedForSegment(segA.A, segA.B, C) && Calculus.IsContainedForSegment(segB.A,segB.B,C))
                    intersect.Add(C);
            }
            return new Sequence<GObject>(intersect, intersect.Count);
        }
       
        public SegmentIntersectionSegment(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Segment", "Segment", this);
        }
    }
}
