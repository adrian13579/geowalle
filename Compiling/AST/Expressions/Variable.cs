using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class VariableCall : Expression
    {
        public IdNode Name { get; set; }


        public VariableCall(IdNode name, CodeLocation codeLoc)
        {
            Name = name;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            if (!context.IsDifined(Name))
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Expected, "La variable " + Name.Name + " no esta definida."));
            }
           // else context.Define(Name);
        }

        public override GObject EvaluateOn(ExecutionScope memory, List<CompilingError> errors)
        {
            return memory.GetVariableValue(Name);
        }
    }
}

