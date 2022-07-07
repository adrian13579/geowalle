using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;

namespace Compiling.AST
{
    public class Samples : Expression
    {
        public Samples(CodeLocation codeLoc)
        {
            CodeLocation = codeLoc;
        }
        public override void CheckSemantics(SemanticScope context, List<CompilingError> errors)
        {
        }

        public override GObject EvaluateOn(ExecutionScope memory, List<CompilingError> errors)
        {
            return new Sequence<GObject>(RandomsPoints(memory.Random));
        }
        private IEnumerable<GPoint> RandomsPoints(Random r)
        {
            while (true)
            {
                yield return new GPoint(r.Next(100,600),r.Next(100,300));
            }
        }
    }
}
