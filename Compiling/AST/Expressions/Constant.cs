using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using Compiling.Operator;

namespace Compiling.AST
{
    public class Constant : Expression
    {
        public GObject Value { get; set; }
     
        public Constant(GObject value,CodeLocation codeLoc)
        {
            Value = value;
            CodeLocation = codeLoc;
        }
        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            return Value;
        }

        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
        }
    }
}
