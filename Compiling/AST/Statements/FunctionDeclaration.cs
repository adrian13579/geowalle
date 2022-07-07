using Compiling.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class FunctionDeclaration : Statement
    {
        public IdNode Name { get; }
        public List<IdNode> Args { get; }
        public Expression Body { get; }
        public FunctionDeclaration(IdNode name, List<IdNode> args, Expression body, CodeLocation codeLoc)
        {
            Name = name;
            Args = args;
            Body = body;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            Name.CheckSemantics(context, errors);
            foreach (var arg in Args)
            {
                arg.CheckSemantics(context, errors);
            }
            SemanticScope son = context.CreateChild();
            for (int i = 0; i < Args.Count; i++)
            {
                son.Define(Args[i]);
            }
            context.Define(Name, Args);

            Body.CheckSemantics(son, errors);
        }

        public override void Execute(ExecutionScope memory,List<CompilingError>errors)
        {
            memory.DeclareFunction(Name, Args, Body);
        }
    }
}
