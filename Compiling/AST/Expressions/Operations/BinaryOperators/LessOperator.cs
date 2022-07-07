using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class LessOperator : BinaryOperator
    {
        public LessOperator(Expression leftOperand, Expression rigthOperand, CodeLocation codeLoc) : base(leftOperand, rigthOperand, codeLoc)
        {
        }

        public override string OperationIdentifier()
        {
            return "<";
        }
    }
}
