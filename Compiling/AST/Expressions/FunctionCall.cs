using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class FunctionCall : Expression
    {
        public IdNode Name { get; set; }
        public List<Expression> Args { get; set; }
      
        public FunctionCall(IdNode name, List<Expression> args,CodeLocation codeLoc)
        {
            Name = name;
            Args = args;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            if (!context.IsDifined(Name, Args.Count))
            {
                errors.Add(new CompilingError(Name.CodeLocation, ErrorCode.Expected, "La funcion " + Name.Name + "  no esta definida."));
            }
            foreach (var expression in Args)
            {
                expression.CheckSemantics(context, errors);
            }
        }

        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            return memory.EvaluateFunction(Name, Args,errors);
        }
    }
}
