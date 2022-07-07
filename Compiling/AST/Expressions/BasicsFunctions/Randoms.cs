using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class Randoms : Expression
    {
        
        
        public Randoms(CodeLocation codeLoc)
        {
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
        }

        public override GObject EvaluateOn(ExecutionScope memory, List<CompilingError> errors)
        {
            return new Sequence<GObject>(RandomsNumber(memory.Random));
            
        }
        private IEnumerable<Number> RandomsNumber(Random r)
        {
            while (true)
            {
                yield return new Number(r.Next(-500,500)); 
            }
        }
    }
}
