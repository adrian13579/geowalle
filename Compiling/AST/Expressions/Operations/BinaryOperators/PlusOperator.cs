using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using Compiling.Operator;

namespace Compiling.AST
{
    public class PlusOperator : BinaryOperator
    {
        public PlusOperator(Expression leftOperand, Expression rigthOperand, CodeLocation codeLoc) : base(leftOperand, rigthOperand, codeLoc)
        {
        }

        public override string OperationIdentifier()
        {
            return "+";
        }
    }
}
