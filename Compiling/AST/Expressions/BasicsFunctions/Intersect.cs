using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class Intersect : Expression
    {
        public Expression A { get; }
        public Expression B { get; }
        public Intersect(Expression a,Expression b,CodeLocation codeLoc)
        {
            A = a;
            B = b;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            A.CheckSemantics(context, errors);
            B.CheckSemantics(context, errors);
        }

        public override GObject EvaluateOn(ExecutionScope memory, List<CompilingError> errors)
        {
            GObject a = A.EvaluateOn(memory, errors);
            GObject b = B.EvaluateOn(memory, errors);
           
            if (memory.Op.IsOperationDifined(a, b, "Intersect"))
            {
                return memory.Op.Operate(a, b, "Intersect");
            }
            else
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "La interseccion no esta definida para estos tipos"));
                return null;
            }
        }
    }
}
