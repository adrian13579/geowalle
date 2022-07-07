using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public abstract class ConstructorExpression : Expression
    {
        public List<Expression> Args { get; }
        public ConstructorExpression(List<Expression> args,CodeLocation codeLoc)
        {
            Args = args;
            CodeLocation = codeLoc;
        }
        public abstract bool CheckArgsCount(List<CompilingError> errors);
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            foreach (var arg in Args)
            {
                arg.CheckSemantics(context, errors);
            }
            if (!CheckArgsCount(errors))
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Expected, "La cantidad de parametros es incorrecta."));
              
            }
        }
    }
}
