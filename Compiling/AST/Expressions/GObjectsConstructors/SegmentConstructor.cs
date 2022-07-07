using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class SegmentConstructor : ConstructorExpression
    {
        public SegmentConstructor(List<Expression> args, CodeLocation codeLoc) : base(args, codeLoc)
        {
        }

        public override bool CheckArgsCount(List<CompilingError> errors)
        {
            return Args.Count == 2;
        }

        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            GPoint point1 = Args[0].EvaluateOn(memory, errors) as GPoint;
            GPoint point2 = Args[1].EvaluateOn(memory, errors) as GPoint;
            if (point1 == null || point2 == null)
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "El constructor de Segment debe recibir dos puntos"));
                return null;
            }
            return new Segment(point1, point2);
        }
    }
}
