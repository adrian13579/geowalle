using Compiling.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiling.AST
{
    public class ProgramNode : ASTNode
    {
        public List<Statement> Instructions { get; }
        public ProgramNode(List<Statement> instructions)
        {
            Instructions = instructions;
        }
        public void Run(ExecutionScope memory, List<CompilingError> errors)
        {
            foreach (var item in Instructions)
            {
                item.Execute(memory,errors);
            }
        }
        public override void CheckSemantics(SemanticScope context,List<CompilingError>errors)
        {
            foreach (var instruction in Instructions)
            {
                instruction.CheckSemantics(context, errors);
            }
        }
    }
}
