using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class NotNumberOperator : IUnaryOperator
    {
        public string Identifier { get { return "Not"; } }

        public GObject Operate(GObject a)
        {
            Number num = a as Number;
            return (num.Value == 0) ? new Number(0) : new Number(1);
        }
        public NotNumberOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterUnaryOperator("Number", this);
        }
    }
}
