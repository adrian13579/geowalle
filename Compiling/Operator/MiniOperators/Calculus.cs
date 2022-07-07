using Compiling.GObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.Operator
{
    public static class Calculus
    {
        public static bool IsContainedForSegment(GPoint a, GPoint b, GPoint c)
        {
            if (a.Y < b.Y && a.X < b.X)
                return c.X >= a.X && c.Y >= a.Y && c.X <= b.X && c.Y <= b.Y;
            if (a.Y < b.Y && a.X > b.X)
                return c.X <= a.X && c.Y >= a.Y && c.X >= b.X && c.Y <= b.Y;
            if (a.Y > b.Y && a.X < b.X)
                return c.X >= a.X && c.Y <= a.Y && c.X <= b.X && c.Y >= b.Y;
            if (a.Y > b.Y && a.X > b.X)
                return c.X <= a.X && c.Y <= a.Y && c.X >= b.X && c.Y >= b.Y;
            return c.X == a.X && c.Y == a.Y;
        }
        public static bool IsContainedForRay(GPoint a, GPoint b, GPoint c)
        {
            if (a.Y < b.Y && a.X < b.X)
                return c.Y >= a.Y && c.X >= a.X;
            if (a.Y < b.Y && a.X > b.X)
                return c.Y >= a.Y && c.X <= a.X;
            if (a.Y > b.Y && a.X < b.X)
                return c.Y <= a.Y && c.X >= a.X;
            if (a.Y > b.Y && a.X > b.X)
                return c.Y <= a.Y && c.X < a.X;
            return c.X == a.X && c.Y == a.Y;
        }
    }
}
