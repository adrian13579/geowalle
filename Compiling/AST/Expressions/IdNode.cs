using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using Compiling.Operator;

namespace Compiling.AST
{
    public class IdNode : Expression
    {
        public string Name { get; set; }
        public IdNode(string name)
        {
            Name = name;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            if (Name[0] == '_')
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Expected, "Hiciste algo turbio con el _"));
            }
        }

        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            return null;
        }
    }
}
