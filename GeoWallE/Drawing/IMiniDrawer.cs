using Compiling.GObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoWallE
{
    public interface IMiniDrawer
    {
        void SelfRegister(CanvasDrawer canvas);

        void Draw(GObject figure ,string color,string label,Canvas canvas);
    }
}
