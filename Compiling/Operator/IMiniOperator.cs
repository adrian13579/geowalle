using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.Operator
{
    public interface IMiniOperator
    {
        void SelfRegister(Operator op);
    }
}
