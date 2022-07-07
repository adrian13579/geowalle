using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;
using Compiling.Operator;
using Compiling.GObjects;

namespace Compiling
{
    public class SemanticScope
    {
        
        #region InternalVariables
        SemanticScope parent;
        List<string> variables = new List<string>();
        Dictionary<string, List<List<IdNode>>> functions = new Dictionary<string, List<List<IdNode>>>();
        List<string> importedPrograms = new List<string>();
        #endregion

        #region Properties
        public SemanticScope Parent { get { return parent; } }
        public Operator.Operator Operator { get; }
        #endregion

        #region Constructor
        public SemanticScope()
        {
            Operator = new Operator.Operator();
        }
        #endregion

        #region IsDifined
        public bool IsDifined(IdNode variable)
        {
            if (variables.Contains(variable.Name))
                return true;

            return parent != null && parent.IsDifined(variable);
        }
        public bool IsDifined(IdNode function, int arg)
        {
            List<List<IdNode>> functionArgs;
            if (functions.TryGetValue(function.Name, out functionArgs))
            {
                foreach (var functionArg in functionArgs)
                {
                    if (functionArg.Count == arg)
                        return true;
                }
            }
            return parent != null && parent.IsDifined(function, arg);
        }
        #endregion

        #region Difine
        public bool Define(IdNode variable)
        {
            if (variable.Name != "Underscore")
                variables.Add(variable.Name);
            return true;
        }
        public bool Define(IdNode function, List<IdNode> arg)
        {
            List<List<IdNode>> functionArgs;
            if (functions.TryGetValue(function.Name, out functionArgs))
            {
                functionArgs.Add(arg);
                functions[function.Name] = functionArgs;
                return true;
            }
            functionArgs = new List<List<IdNode>>();
            functionArgs.Add(arg);
            functions.Add(function.Name, functionArgs);
            return true;
        }
        #endregion

        #region OthersMethods
        public bool ImportProgram( Text text )
        {
            if (importedPrograms.Contains(text.Content))
                return false;
            importedPrograms.Add(text.Content);
            return true;
        }
        public SemanticScope CreateChild()
        {
            return new SemanticScope() { parent = this };
        }
        #endregion
    }
}
