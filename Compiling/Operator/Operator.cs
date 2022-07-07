using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.GObjects;
using System.IO;
using System.Reflection;

namespace Compiling.Operator
{
    public class Operator
    {
        #region InternalVariables
        Dictionary<Tuple<string, string>, List<IBinaryOperator>> binaryOperators = new Dictionary<Tuple<string, string>, List<IBinaryOperator>>();
        Dictionary<string, List<IUnaryOperator>> unaryOperators = new Dictionary<string, List<IUnaryOperator>>();
        #endregion

        #region Register
        public void RegisterBinaryOperator(string left, string rigth, IBinaryOperator op)
        {
            List<IBinaryOperator> operation;
            Tuple<string, string> key = new Tuple<string, string>(left, rigth);
            if (binaryOperators.TryGetValue(key, out operation))
            {
                operation.Add(op);
                binaryOperators[key] = operation;
                return;
            }
            operation = new List<IBinaryOperator>();
            operation.Add(op);
            binaryOperators.Add(key, operation);
        }
        public void RegisterUnaryOperator(string a, IUnaryOperator op)
        {
            List<IUnaryOperator> operation;
            string key = a;
            if (unaryOperators.TryGetValue(a, out operation))
            {
                operation.Add(op);
                unaryOperators[key] = operation;
                return;
            }
            operation = new List<IUnaryOperator>();
            operation.Add(op);
            unaryOperators.Add(key, operation);
        }
        #endregion

        #region Constructor
        public Operator()
        {
            var directory = Directory.GetCurrentDirectory();
            foreach (var file in Directory.GetFiles(directory))
            {
                if (Path.GetExtension(file) != ".exe" && Path.GetExtension(file) != ".dll")
                    continue;
                var assembly = Assembly.LoadFile(file);
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract && typeof(IMiniOperator).IsAssignableFrom(type))
                    {
                        Activator.CreateInstance(type, this);
                    }
                }
            }
        }
        #endregion

        #region Operate
        public GObject Operate(GObject left, GObject rigth, string identifier)
        {
            List<IBinaryOperator> binaryOp;
            if (binaryOperators.TryGetValue(new Tuple<string, string>(left.GObjectType(), rigth.GObjectType()), out binaryOp))
            {
                foreach (var op in binaryOp)
                {
                    if (op.Identifier == identifier)
                        return op.Operate(left, rigth);
                }
            }
            return null;
        }
        public GObject Operate(GObject a, string identifier)
        {
            List<IUnaryOperator> unaryOp;
            if (unaryOperators.TryGetValue(a.GObjectType(), out unaryOp))
            {
                foreach (var op in unaryOp)
                {
                    if (op.Identifier == identifier)
                        return op.Operate(a);
                }
            }
            return null;
        }
        #endregion

        #region IsOperationDifined
        public bool IsOperationDifined(GObject a, string identifier)
        {
            List<IUnaryOperator> unaryOp;
            if (unaryOperators.TryGetValue(a.GObjectType(), out unaryOp))
            {
                foreach (var op in unaryOp)
                {
                    if (op.Identifier == identifier)
                        return true;
                }
            }
            return false;
        }
        public bool IsOperationDifined(GObject left, GObject rigth, string identifier)
        {
            List<IBinaryOperator> binaryOp;
            if (binaryOperators.TryGetValue(new Tuple<string, string>(left.GObjectType(), rigth.GObjectType()), out binaryOp))
            {
                foreach (var op in binaryOp)
                {
                    if (op.Identifier == identifier)
                        return true;
                }
            }
            return false;
        }
        #endregion

    }
}
