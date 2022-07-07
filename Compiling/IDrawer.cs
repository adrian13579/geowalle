using Compiling.GObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling
{
    public interface IDrawer
    {
        void SetColor(GColor color);
        void RestoreColor();
        bool IsDrawable(GObject figure);
        void Draw(GObject figure,string label);
    }
}
