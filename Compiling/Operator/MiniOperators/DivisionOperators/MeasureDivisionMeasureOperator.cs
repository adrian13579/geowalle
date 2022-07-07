using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    class MeasureDivisionMeasureOperator : IBinaryOperator
    {
        public string Identifier { get { return "/"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Measure m1 = a as Measure;
            Measure m2 = b as Measure;
            if (m2.Value == 0)
                return new Undifined();
            return new Number((int)m1.Value /(int)m2.Value);
        }
        public MeasureDivisionMeasureOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Measure", "Measure", this);
        }
    }
}
