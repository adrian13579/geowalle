using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class RayIntersectionCircle : IBinaryOperator
    {
        public string Identifier { get { return "Intersect"; } }
        public GObject Operate(GObject a, GObject b)
        {
            Ray ray = a as Ray;
            Circle circle = b as Circle;
            IBinaryOperator lineIntersectCircle = new LineIntersectionCircle();
            List<GObject> intersect = new List<GObject>();

            Sequence<GObject> lineCircleIntersect = lineIntersectCircle.Operate(ray.Line, circle) as Sequence<GObject>;
            if (lineCircleIntersect == null)
                return new Undifined();

            foreach (var item in lineCircleIntersect.Items)
            {
                var C = item as GPoint;
                if (Calculus.IsContainedForRay(ray.A, ray.B, C))
                    intersect.Add(C);
            }
            return new Sequence<GObject>(intersect, intersect.Count);
        }
        
        public RayIntersectionCircle(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Ray", "Circle", this);
        }
    }
}
