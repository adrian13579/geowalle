using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class RayIntersectionLine : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; }}

        public GObject Operate(GObject a, GObject b)
        {
            Ray ray = a as Ray;
            Line line = b as Line;
            IBinaryOperator lineIntersectLine = new LineIntersectionLine();
            List<GObject> intersect = new List<GObject>();

            Sequence<GObject> lineLineIntersect = lineIntersectLine.Operate(ray.Line, line) as Sequence<GObject>;
            if (lineLineIntersect == null)
                return new Undifined();

            foreach (var item in lineLineIntersect.Items)
            {
                var C = item as GPoint;
                if (Calculus.IsContainedForRay(ray.A, ray.B, C))
                    intersect.Add(C);
            }
            return new Sequence<GObject>(intersect, intersect.Count);
        }
        public RayIntersectionLine(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Ray", "Line", this);
        }
    }
}
