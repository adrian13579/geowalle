using Compiling.AST;
using Compiling.GObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Compiling
{
    public class FunctionInfo
    {
        public Expression FunctionBody { get; }
        public ExecutionScope ExScope { get; private set; }
        public List<IdNode> Args { get; }
        public FunctionInfo(Expression functionBody, List<IdNode> args)
        {
            FunctionBody = functionBody;
            Args = args;
        }
        public GObject EvaluateOn(List<Expression> args, ExecutionScope parentScope,IdNode name, FunctionInfo function,List<CompilingError>errors)
        {
            ExScope = parentScope.CreateChild();
            for (int i = 0; i < Args.Count; i++)
            {
                ExScope.DeclareVariable(Args[i], args[i].EvaluateOn(parentScope,errors));
            }
            return FunctionBody.EvaluateOn(ExScope,errors);
        }
    }

}
