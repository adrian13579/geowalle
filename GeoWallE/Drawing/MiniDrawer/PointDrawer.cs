using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using System.Drawing;

namespace GeoWallE
{
    public class PointDrawer : IMiniDrawer
    {
        public void Draw(GObject figure, string color,string label, Canvas canvas)
        {
            GPoint p = figure as GPoint;
            canvas.SetColor(Color.FromName(color));
            canvas.DrawPoint(new Point((int)p.X, (int)p.Y), label);
            canvas.Refresh();
        }
        public PointDrawer(CanvasDrawer canvas)
        {
            SelfRegister(canvas);
        }
        public void SelfRegister(CanvasDrawer canvas)
        {
            canvas.RegisterMiniDrawer("Point", this);
        }
    }
}
