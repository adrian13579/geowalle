using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    class MeasurePlusMeasureOperator : IBinaryOperator
    {
        public string Identifier { get { return "+"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Measure m1 = a as Measure;
            Measure m2 = b as Measure;
            return new Measure(m1.Value + m2.Value); 
        }
        public MeasurePlusMeasureOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Measure", "Measure", this);
        }
    }
}
