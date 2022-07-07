using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class AndOperator : BinaryOperator
    {
        public AndOperator(Expression leftOperand, Expression rigthOperand, CodeLocation codeLoc) : base(leftOperand, rigthOperand, codeLoc)
        {
        }

        public override string OperationIdentifier()
        {
            return "And";
        }
    }
}
