using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    public class NumberPlusNumberOperator : IBinaryOperator
    {
        public string Identifier { get { return "+"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Number left = a as Number;
            Number right = b as Number;
            return new Number(left.Value + right.Value);
        }
        public NumberPlusNumberOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Number", "Number", this);
        }
    }
}
