using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class NumberAndNumberOperator : IBinaryOperator
    {
        public string Identifier { get { return "And"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Number num1 = a as Number;
            Number num2 = b as Number;
            return (num1.Value != 0 && num2.Value != 0) ? new Number(1) : new Number(0);
        }
        public NumberAndNumberOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Number", "Number", this);
        }
    }
}
