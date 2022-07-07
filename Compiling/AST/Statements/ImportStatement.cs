using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using System.IO;

namespace Compiling.AST
{
    public class ImportStatement : Statement
    {
        public Text ProgramText { get; }
        public ImportStatement(Text text, CodeLocation codeLoc)
        {
            ProgramText = text;
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
             context.ImportProgram(ProgramText);
        }

        public override void Execute(ExecutionScope context,List<CompilingError>errors)
        {
           
        }
    }
}
