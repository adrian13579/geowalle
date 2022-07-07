using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Compiling.GObjects;
using Compiling;

namespace GeoWallE
{
    public class CanvasDrawer:IDrawer
    {
        #region InternalVariables
        Dictionary<string, IMiniDrawer> painters = new Dictionary<string, IMiniDrawer>();
        Stack<string> colors = new Stack<string>();
        Canvas canvas;
        #endregion;

        #region Constructor
        public CanvasDrawer(Canvas canvas)
        {
            this.canvas = canvas;
            var directory = Directory.GetCurrentDirectory();
            foreach (var file in Directory.GetFiles(directory))
            {
                if (Path.GetExtension(file) != ".exe" && Path.GetExtension(file) != ".dll")
                    continue;
                var assembly = Assembly.LoadFile(file);
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract && typeof(IMiniDrawer).IsAssignableFrom(type))
                    {
                        Activator.CreateInstance(type, this);
                    }
                }
            }
        }
        #endregion

        #region Register
        public void RegisterMiniDrawer(string id, IMiniDrawer drawer)
        {
            painters.Add(id, drawer);
        }
        #endregion

        #region Draw
        public void Draw(GObject figure, string label)
        {
            if (figure.GObjectType() == "Sequence")
            {
                Sequence<GObject> figureSequence = figure as Sequence<GObject>;
                foreach (var fig in figureSequence.Items)
                {
                    Draw(fig, label);
                }
            }
            else
            {
                IMiniDrawer drawer;
                if (painters.TryGetValue(figure.GObjectType(), out drawer))
                {
                    string color = "Black";
                    if (colors.Count != 0)
                        color = colors.Peek();
                    drawer.Draw(figure, color, label, canvas);
                }
            }
        }

        public bool IsDrawable(GObject figure)
        {
            if (figure.GObjectType() == "Sequence")
            {
                Sequence<GObject> figureSequence = figure as Sequence<GObject>;
                foreach (var fig in figureSequence.Items)
                {
                    if (!IsDrawable(fig))
                        return false;
                }
                return true;
            }
            else
            {
                IMiniDrawer drawer;
                if (figure == null) return false;
                return painters.TryGetValue(figure.GObjectType(), out drawer);
            }
        }
        #endregion

        #region SettingColor
        public void SetColor(GColor color)
        {
            colors.Push(color.Color);
        }
        public void RestoreColor()
        {
            if (colors.Count != 0)
                colors.Pop();
        }
        #endregion
    }
}
