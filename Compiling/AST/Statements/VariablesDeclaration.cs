using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class VariablesDeclaration : Statement
    {
        public List<IdNode> VariablesName { get; }
        public Expression Values { get; }
        public VariablesDeclaration(List<IdNode> variablesName,Expression values,CodeLocation codeLoc)
        {
            CodeLocation = codeLoc;
            VariablesName = variablesName;
            Values = values; 
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
            foreach (var item in VariablesName)
            {
                if (!context.IsDifined(item))
                {
                    context.Define(item);
                }
                else errors.Add(new CompilingError(CodeLocation, ErrorCode.Expected, "La variable ya fue declarada"));
            }
            Values.CheckSemantics(context, errors);
        }

        public override void Execute(ExecutionScope memory,List<CompilingError>errors)
        {
            var values = Values.EvaluateOn(memory,errors);
            if (values == null)
                return;
            if (values.IsASequence())
            {
                int index = 0;
                Sequence<GObject> seq = values as Sequence<GObject>;
                foreach (var item in seq.Items)
                {
                    if (index < VariablesName.Count - 1)
                    {
                        memory.DeclareVariable(VariablesName[index++], item);
                    }
                    else break;
                }
                if (index < VariablesName.Count)
                {
                    while (index<VariablesName.Count-1)
                    {
                        memory.DeclareVariable(VariablesName[index++], new Undifined());
                    }
                    memory.DeclareVariable(VariablesName[VariablesName.Count - 1], new Sequence<GObject>(seq.Items.Skip<GObject>(index)));
                }
            }
            else
            {
                memory.DeclareVariable(VariablesName[0], values);
            }
        }
    }
}
