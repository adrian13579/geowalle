using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    class ColorStatement : Statement
    {
        public Expression Color { get; }
        public ColorStatement(Expression color, CodeLocation codeLoc)
        {
            Color = color;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            Color.CheckSemantics(context, errors);
        }

        public override void Execute(ExecutionScope memory, List<CompilingError> errors)
        {
            GColor color = Color.EvaluateOn(memory, errors) as GColor;
            if (color == null)
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "Se esperaba un color."));
            }
            else
            {
                memory.Drawer.SetColor(color);
            }
        }
    }
}
