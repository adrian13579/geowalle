using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    class DrawStatement : Statement
    {
        public Expression GObjects { get; }
        public Expression Label { get; }
        public DrawStatement(Expression objects, Expression label, CodeLocation codeLoc)
        {
            GObjects = objects;
            Label = label;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            GObjects.CheckSemantics(context, errors);
            if (Label != null)
                Label.CheckSemantics(context, errors);
        }

        public override void Execute(ExecutionScope memory, List<CompilingError> errors)
        {
            GObject toDraw = GObjects.EvaluateOn(memory, errors);
            if (toDraw!=null &&  memory.Drawer.IsDrawable(toDraw))
            {
                if (Label != null)
                {
                    Text label = Label.EvaluateOn(memory, errors) as Text;
                    if (label != null)
                    {
                        memory.Drawer.Draw(toDraw, label.Content);
                    }
                    else
                    {
                        errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "El label es incorrecto"));
                    }

                }
                else
                {
                    memory.Drawer.Draw(toDraw,null);
                }
            }
            else
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "No es posible dibujar el objeto"));
            }

        }
    }
}
