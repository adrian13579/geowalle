using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using Compiling.Operator;

namespace Compiling.AST
{
    public class SequenceExpression : Expression
    {
        public Expression threePointsOperator { get; }
        public IEnumerable<Expression> Items { get; }

      
        public SequenceExpression(IEnumerable<Expression> items, CodeLocation codeLoc)
        {
            Items = items;
            CodeLocation = CodeLocation;
        }
        public SequenceExpression(Expression a)
        {
            threePointsOperator = a;
        }

        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            if (threePointsOperator != null)
                 threePointsOperator.CheckSemantics(context, errors);
        }

        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            if (Items != null)
            {
                List<GObject> objects = new List<GObject>();
                List<Expression> items = new List<Expression>(Items);
                for (int i = 0; i < items.Count-1; i++)
                {
                    GObject  newObject = items[i].EvaluateOn(memory, errors);
                    if (newObject.IsSameTypeAs(items[i + 1].EvaluateOn(memory, errors)))
                    {
                        objects.Add(newObject);
                    }
                    else
                    {
                        errors.Add(new CompilingError(CodeLocation, ErrorCode.Expected, "Los elementos de la secuencia no son del mismo tipo."));
                        return null;
                    }
                }
                objects.Add(items[items.Count - 1].EvaluateOn(memory, errors));
                return new Sequence<GObject>(objects,items.Count);
            }
            return threePointsOperator.EvaluateOn(memory,errors);
        }
    }
}
