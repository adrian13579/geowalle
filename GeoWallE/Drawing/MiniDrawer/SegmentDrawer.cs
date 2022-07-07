using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using System.Drawing;

namespace GeoWallE
{
    public class SegmentDrawer : IMiniDrawer
    {
        public void Draw(GObject figure, string color, string label, Canvas canvas)
        {
            Segment seg = figure as Segment;
            canvas.SetColor(Color.FromName(color));
            canvas.DrawSegment(new Point((int)seg.A.X, (int)seg.A.Y), new Point((int)seg.B.X, (int)seg.B.Y), label);
            canvas.Refresh();
        }
        public SegmentDrawer(CanvasDrawer canvas)
        {
            SelfRegister(canvas);
        }
        public void SelfRegister(CanvasDrawer canvas)
        {
            canvas.RegisterMiniDrawer("Segment", this);
        }
    }
}
