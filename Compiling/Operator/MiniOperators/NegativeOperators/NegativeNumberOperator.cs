using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    class NegativeNumberOperator : IUnaryOperator
    {
        public string Identifier { get { return "-"; } }

        public GObject Operate(GObject a)
        {
            Number n = a as Number;
            return new Number(n.Value * -1);
        }
        public NegativeNumberOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterUnaryOperator("-", this);
        }
    }
}
