using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
   public abstract class UnaryOperator : OperationNode
    {
        public Expression Operand { get; }
        public UnaryOperator(Expression  operand, CodeLocation codeLoc)
        {
            Operand = operand;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
           Operand.CheckSemantics(context, errors);
        }

        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            GObject operand = Operand.EvaluateOn(memory, errors);
            if (memory.Op.IsOperationDifined(operand, OperationIdentifier()))
            {
                return memory.Op.Operate(operand, OperationIdentifier());
            }
            else
            {
                string operandType;
                if (operand == null)
                {
                    operandType = "Unknown";
                }
                else
                {
                    operandType = operand.GObjectType();
                }
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "La operacion " + OperationIdentifier()+"no esta definida con "+operandType));
                return null;
            }
        }
    }
}
