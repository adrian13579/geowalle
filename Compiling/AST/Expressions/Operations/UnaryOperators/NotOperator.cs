using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class NotOperator : UnaryOperator
    {
        public NotOperator(Expression operand, CodeLocation codeLoc) : base(operand, codeLoc)
        {
        }

        public override string OperationIdentifier()
        {
            return "Not";
        }
    }
}
