using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using Compiling.AST;
using Compiling.Operator;

namespace Compiling.AST
{
    class LetInExpresison : Expression
    {
        public List<Statement> LetInstructions { get; }
        public Expression InExpression { get; }
        public LetInExpresison(List<Statement> letInstructions,Expression inExpression, CodeLocation codeLoc)
        {
            LetInstructions = letInstructions;
            InExpression = inExpression;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            SemanticScope childContext = context.CreateChild();
            foreach (var instruction in LetInstructions)
            {
                instruction.CheckSemantics(childContext, errors);
            }
            InExpression.CheckSemantics(childContext, errors);
        }
        public override GObject EvaluateOn(ExecutionScope memory,List<CompilingError>errors)
        {
            ExecutionScope scope = memory.CreateChild();
            foreach (var instruction in LetInstructions)
            {
                instruction.Execute(scope,errors);
            }
            return InExpression.EvaluateOn(scope,errors);
        }
    }
}
