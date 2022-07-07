using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    class NegativeOperator : UnaryOperator
    {
        public NegativeOperator(Expression operand, CodeLocation codeLoc) : base(operand, codeLoc)
        {
        }

        public override string OperationIdentifier()
        {
            return "-";
        }
    }
}
