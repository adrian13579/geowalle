using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using Compiling.AST;
using Compiling.Operator;

namespace Compiling.AST
{
    public class ThreePointsOperator : BinaryOperator
    {
        public ThreePointsOperator(Expression leftOperand, Expression rigthOperand, CodeLocation codeLoc) : base(leftOperand, rigthOperand, codeLoc)
        {
        }

        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            if (RigthOperand == null)
            {
                LeftOperand.CheckSemantics(context, errors);
            }
            else base.CheckSemantics(context, errors);
        }
        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            if (RigthOperand == null)
            {
                GObject operand = LeftOperand.EvaluateOn(memory, errors);
                if (memory.Op.IsOperationDifined(operand, OperationIdentifier()))
                {
                    return memory.Op.Operate( operand, OperationIdentifier());
                }
                else
                {
                    errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "La operacion " + OperationIdentifier() + "con el tipo "));
                    return null;
                }
            }
            return base.EvaluateOn(memory,errors);
        }
        public override string OperationIdentifier()
        {
            return "...";
        }
    }
}
