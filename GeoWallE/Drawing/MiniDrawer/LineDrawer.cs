using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using System.Drawing;

namespace GeoWallE
{
    public class LineDrawer : IMiniDrawer
    {
        public void Draw(GObject figure, string color, string label, Canvas canvas)
        {
            Line line = figure as Line;
            canvas.SetColor(Color.FromName(color));
            canvas.DrawLine(new Point((int)line.PointA.X, (int)line.PointA.Y), new Point((int)line.PointB.X, (int)line.PointB.Y),label);
            canvas.Refresh();
        }
        public LineDrawer(CanvasDrawer canvas)
        {
            SelfRegister(canvas);
        }
        public void SelfRegister(CanvasDrawer canvas)
        {
            canvas.RegisterMiniDrawer("Line", this);
        }
    }
}
