using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    class NumberThreePointsOperator : IUnaryOperator
    {
        public string Identifier { get { return "..."; } }

        public GObject Operate(GObject a)
        {
            Number num = a as Number;
            return new Sequence<Number >(IntervalInf(num)); 
        }
        public NumberThreePointsOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterUnaryOperator("Number", this);
       
        }
        private IEnumerable<Number> IntervalInf(Number lower)
        {
            for (int i = (int)lower.Value; ; i++)
            {
                yield return new Number(i);
            }
        }
    }
}
