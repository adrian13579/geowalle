using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class NumberGreaterNumberOperator : IBinaryOperator
    {
        public string Identifier { get { return ">"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Number left = a as Number;
            Number right = b as Number;
            return (left.Value > right.Value) ? new Number(1) : new Number(0);
        }
        public NumberGreaterNumberOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Number", "Number", this);
        }
    }
}
