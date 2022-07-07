using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class CircleConstructor : ConstructorExpression
    {
        public CircleConstructor(List<Expression> args, CodeLocation codeLoc) : base(args, codeLoc)
        {
        }

        public override bool CheckArgsCount(List<CompilingError> errors)
        {
            return Args.Count == 2;
        }

        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            GPoint point1 = Args[0].EvaluateOn(memory, errors) as GPoint;
            //esto lo cambie parar probar un fractal
            GObject measure = Args[1].EvaluateOn(memory, errors);
            if(measure is Measure)
            {
                return new Circle(point1, measure as Measure);
            }
            if(measure is Number)
            {
                return new Circle(point1, measure as Number);
            }
            if(point1==null || measure== null)
            {
                errors.Add(new CompilingError(CodeLocation, ErrorCode.Invalid, "El constructor de Circle debe recibir un punto y un measure"));
                return null;
            }
            // return new Circle(point1, measure);
            return null;
        }
    }
}

