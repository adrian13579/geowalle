using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling;

namespace Compiling.GObjects
{
    public class GPoint : GObject
    {
        static Random r = new Random();
        public double X { get; }
        public double Y { get; }
        public GPoint()
        {
            X = r.NextDouble()+r.Next(200,500);
            Y = r.NextDouble()+r.Next(200,500);
        }
        public GPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string GObjectType()
        {
            return "Point";
        }

        public override bool IsASequence()
        {
            return false;
        }
    }
}
