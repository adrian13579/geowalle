using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using Compiling.Operator;

namespace Compiling.AST
{
    class IfThenElseExpression : Expression
    {
        public Expression IfExpression { get; }
        public Expression ThenExpression { get; }
        public Expression ElseExpression { get; }

        public IfThenElseExpression(Expression ifExpression, Expression thenExpression, Expression elseExpression, CodeLocation codeLoc)
        {
            IfExpression = ifExpression;
            ThenExpression = thenExpression;
            ElseExpression = elseExpression;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            IfExpression.CheckSemantics(context, errors);
            ThenExpression.CheckSemantics(context, errors);
            ElseExpression.CheckSemantics(context, errors);
        }

        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            Number boolean = IfExpression.EvaluateOn(memory,errors) as Number;
            if (boolean != null)
            {
                if (boolean.Value == 0)
                    return ElseExpression.EvaluateOn(memory,errors);
                else return ThenExpression.EvaluateOn(memory,errors);
            }
            ///esto esta mal!!!!s
            return null;
        }
    }
}
