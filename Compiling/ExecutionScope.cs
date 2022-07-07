using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;
using Compiling.GObjects;
using Compiling.Operator;
using Compiling;

namespace Compiling
{
    public class ExecutionScope
    {
        #region InternalVariables
        public Dictionary<string, GObject> variables = new Dictionary<string, GObject>();
        public Dictionary<string, List<FunctionInfo>> functions = new Dictionary<string, List<FunctionInfo>>();
        static Random random = new Random(9);
        #endregion

        #region Properties
        public ExecutionScope Parent { get; private set; }
        public Operator.Operator Op { get; }
        public IDrawer Drawer { get; }
        public Random Random { get { return random; } }
        public int RandomSeed { get { return 3; } }
        #endregion

        #region Constructor
        public ExecutionScope(IDrawer drawer)
        {
            Drawer = drawer;
            Op = new Operator.Operator();
            // random = new Random(Environment.TickCount);
        }
        #endregion

        #region Declare
        public void DeclareVariable(IdNode variable, GObject value)
        {
            if (variable.Name != "Underscore")
                variables.Add(variable.Name, value);
        }
        public void DeclareFunction(IdNode function, List<IdNode> args, Expression body)
        {
            FunctionInfo newFunction = new FunctionInfo(body, args);
            List<FunctionInfo> temp;
            if (functions.TryGetValue(function.Name, out temp))
            {
                temp.Add(newFunction);
                functions[function.Name] = temp;
                return;
            }
            else temp = new List<FunctionInfo>();
            temp.Add(newFunction);
            functions.Add(function.Name, temp);
        }
        #endregion

        #region Call
        public GObject EvaluateFunction(IdNode function, List<Expression> args, List<CompilingError> errors)
        {
            List<FunctionInfo> info;
            if (!functions.TryGetValue(function.Name, out info))
            {
                return Parent.EvaluateFunction(function, args, errors);
            }
            foreach (var funct in functions[function.Name])
            {
                if (funct.Args.Count == args.Count)
                {
                    return funct.EvaluateOn(args, this, function, funct, errors);
                }
            }
            return null;
        }
        public GObject GetVariableValue(IdNode variable)
        {
            GObject value;
            if (variables.TryGetValue(variable.Name, out value))
                return value;

            if (Parent != null)
                return Parent.GetVariableValue(variable);

            return null;
        }
        #endregion

        #region OtherMethods
        public ExecutionScope CreateChild()
        {
            ExecutionScope son = new ExecutionScope(Drawer) { Parent = this };
            foreach (var item in functions)
            {
                son.functions.Add(item.Key, item.Value);
            }
            return son;
        }
        #endregion
    }

}


