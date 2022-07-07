using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using System.Drawing;

namespace GeoWallE
{
    public class CircleDrawer : IMiniDrawer
    {
        public void Draw(GObject figure, string color, string label, Canvas canvas)
        {
            Circle circle = figure as Circle;
            canvas.SetColor(Color.FromName(color));
            canvas.DrawCircle(new Point((int)circle.Center.X, (int)circle.Center.Y), (int)circle.Radius, label);
            canvas.Refresh();
        }
        public CircleDrawer(CanvasDrawer canvas)
        {
            SelfRegister(canvas);
        }
        public void SelfRegister(CanvasDrawer canvas)
        {
            canvas.RegisterMiniDrawer("Circle", this);
        }
    }
}
