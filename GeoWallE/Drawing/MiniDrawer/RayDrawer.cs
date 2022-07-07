using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using System.Drawing;

namespace GeoWallE
{
    public class RayDrawer : IMiniDrawer
    {
        public void Draw(GObject figure, string color, string label, Canvas canvas)
        {
            Ray ray = figure as Ray;
            canvas.SetColor(Color.FromName(color));
            canvas.DrawRay(new Point((int)ray.A.X,(int) ray.A.Y), new Point((int)ray.B.X, (int)ray.B.Y), label);
            canvas.Refresh();
        }
        public RayDrawer(CanvasDrawer canvas)
        {
            SelfRegister(canvas);
        }
        public void SelfRegister(CanvasDrawer canvas)
        {
            canvas.RegisterMiniDrawer("Ray",this);
        }
    }
}
