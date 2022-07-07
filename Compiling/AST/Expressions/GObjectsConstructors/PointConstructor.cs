using Compiling.GObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class PointConstructor : ConstructorExpression
    {
        public PointConstructor(List<Expression> args, CodeLocation codeLoc) : base(args, codeLoc)
        {
        }
        public override bool CheckArgsCount(List<CompilingError> errors)
        {
            return Args.Count == 2;
        }
        public override GObject EvaluateOn(ExecutionScope memory, List<CompilingError> errors)
        {
            Number num1 = Args[0].EvaluateOn(memory, errors) as Number;
            Number num2 = Args[1].EvaluateOn(memory, errors) as Number;
            if (num1 == null || num2 == null)
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "El constructor de Line debe recibir dos puntos"));
                return null;
            }
            return new GPoint(num1.Value,num2.Value);
        }
    }
}
