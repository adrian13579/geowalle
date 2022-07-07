using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.GObjects
{
    public class Sequence<T> : GObject where T : GObject
    {
        public IEnumerable<T> Items { get; }
        public Number Count { get; }
        public Sequence(IEnumerable<T> items,int count=-1)
        {
            Items = items;
            Count = new Number(count);
        }

        public override string GObjectType()
        {
            return "Sequence";
        }
        public override bool IsASequence()
        {
            return true;
        }
    }
}
