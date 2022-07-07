using Compiling.GObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.Operator;

namespace Compiling.AST
{
    public abstract class BinaryOperator : OperationNode
    {
        public Expression LeftOperand { get; set; }
        public Expression RigthOperand { get; set; }

        public BinaryOperator(Expression leftOperand, Expression rigthOperand, CodeLocation codeLoc)
        {
            CodeLocation = codeLoc;
            LeftOperand = leftOperand;
            RigthOperand = rigthOperand;
        }

        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            LeftOperand.CheckSemantics(context, errors);
            RigthOperand.CheckSemantics(context, errors);
        }

        public override GObject EvaluateOn(ExecutionScope memory, List<CompilingError> errors)
        {
            GObject left = LeftOperand.EvaluateOn(memory, errors);
            GObject rigth = RigthOperand.EvaluateOn(memory, errors);
            if (memory.Op.IsOperationDifined(left, rigth, OperationIdentifier()))
            {
                return memory.Op.Operate(left, rigth, OperationIdentifier());
            }
            else
            {
                string leftType;
                if (left == null)
                {
                    leftType = "Unknown";
                }
                else
                {
                    leftType = left.GObjectType();
                }
                string rigthType;
                if (rigth == null)
                {
                    rigthType = "Unknown";
                }
                else
                {
                    rigthType = rigth.GObjectType();
                }
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "La operacion " + OperationIdentifier() + " no esta definida con los tipos " + leftType + " y " + rigthType));
                return null;
            }
        }
    }
}
