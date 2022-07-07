using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    class NumberThreePointNumberOperator : IBinaryOperator
    {
        public string Identifier { get { return "..."; } }

        public GObject Operate(GObject a, GObject b)
        {
            Number num1 = a as Number;
            Number num2 = b as Number;
            return new Sequence<GObject>(IntervalFin(num1, num2),Math.Abs((int)num1.Value-(int)num2.Value));
        }
        public NumberThreePointNumberOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Number", "Number", this);
        }
       
        private IEnumerable<Number> IntervalFin(Number lower, Number upper)
        {
            for (int i = (int)lower.Value; i <= (int)upper.Value; i++)
            {
                yield return new Number(i);
            }
        }
    }
}
