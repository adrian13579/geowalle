using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
   public abstract class GObjectDeclaration:Statement
    {
        public IdNode Name { get; }
        public Expression Label { get; }
        public GObjectDeclaration(IdNode name, CodeLocation codeLoc)
        {
            Name = name;
            CodeLocation = codeLoc;
        }

        public override void Execute(ExecutionScope context,List<CompilingError>errors)
        {
            throw new Exception();
        }

        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            if (context.IsDifined(Name))
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Expected, "La variable "+Name.Name+" fue declarada"));
            }
            context.Define(Name);
        }
    }
}
