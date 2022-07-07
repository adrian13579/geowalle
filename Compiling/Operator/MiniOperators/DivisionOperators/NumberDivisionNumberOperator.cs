using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.Operator
{
    class NumberDivisionNumberOperator : IBinaryOperator
    {
        public string Identifier { get { return "/"; } }

        public GObject Operate(GObject a, GObject b)
        {
            Number left = a as Number;
            Number right = b as Number;
            if (right.Value == 0)
                return new Undifined();

            return new Number(left.Value/right.Value);
        }
        public NumberDivisionNumberOperator(Operator op)
        {
            SelfRegister(op);
        }
        public void SelfRegister(Operator op)
        {
            op.RegisterBinaryOperator("Number", "Number", this);
        }
    }
}
