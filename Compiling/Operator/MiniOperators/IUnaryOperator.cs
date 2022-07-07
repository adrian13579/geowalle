using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public  interface IUnaryOperator:IMiniOperator
    {
        string Identifier { get; }
        GObject Operate(GObject a);
    }
}
