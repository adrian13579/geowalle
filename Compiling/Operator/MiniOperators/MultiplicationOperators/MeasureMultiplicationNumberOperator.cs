using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    class MeasureMultiplicationNumberOperator : IBinaryOperator
    {
        public string Identifier { get { return "*"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Measure m1 = a as Measure;
            Number m2 = b as Number;
            return new Number((int)m1.Value * Math.Abs((int)m2.Value));
        }
        public MeasureMultiplicationNumberOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Measure", "Number", this);
        }
    }
}
