using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class PointsFunction : Expression
    {
        public Expression Exp { get; }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            Exp.CheckSemantics(context, errors);
        }
        public PointsFunction(Expression exp,CodeLocation codeLoc)
        {
            Exp = exp;
            CodeLocation = codeLoc;
        }
        public override GObject EvaluateOn(ExecutionScope memory, List<CompilingError> errors)
        {
           GObject a = Exp.EvaluateOn(memory, errors);
            if (memory.Op.IsOperationDifined(a, "PointsFunction"))
            {
                return memory.Op.Operate(a,"PointsFunction");
            }
            else
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "La interseccion no esta definida para este tipo"));
                return null;
            }
        }
    }
}
