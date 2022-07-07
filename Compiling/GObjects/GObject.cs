using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.GObjects
{
    public abstract class GObject
    {
        public abstract bool IsASequence();
        public abstract string GObjectType();
        public bool IsSameTypeAs(GObject other)
        {
            if (other != null)
            {
                if (IsASequence() && other.IsASequence())
                {
                    Sequence<GObject> a = this as Sequence<GObject>;
                    Sequence<GObject> b = other as Sequence<GObject>;
                    GObject itemA = a.Items.First();
                    GObject itemB = b.Items.First();
                    return itemA.IsSameTypeAs(itemB);
                }
                if (!IsASequence() && !other.IsASequence())
                {
                    return GObjectType() == other.GObjectType();
                }
            }
            return false;
        }
    }
}
