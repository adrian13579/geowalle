using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;
using System.IO;
using System.Reflection;

namespace Compiling.Parsing
{
    public class DeclarationParser : IStatementParser
    {
        Dictionary<string, IDeclarationParser> declarationParsers = new Dictionary<string, IDeclarationParser>();
        public void Register(string tokenValue,IDeclarationParser parser)
        {
            declarationParsers.Add(tokenValue, parser);
        }
        public Statement Parse(Parser parser)
        {
            Token token = parser.LookAhead(1);
            IDeclarationParser decParser = GetParser(token);
            if (decParser != null)
            {
                return decParser.Parse(parser);
            }
            return null;
        }
        public DeclarationParser(Parser parser)
        {
            var directory = Directory.GetCurrentDirectory();
            foreach (var file in Directory.GetFiles(directory))
            {
                if (Path.GetExtension(file) != ".exe" && Path.GetExtension(file) != ".dll")
                    continue;
                var assembly = Assembly.LoadFile(file);
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract && typeof(IDeclarationParser).IsAssignableFrom(type))
                    {
                        Activator.CreateInstance(type, this);
                    }
                }
            }
            SelfRegister(parser);
        }
        public IDeclarationParser GetParser(Token token)
        {
            if (token != null)
            {
                IDeclarationParser result;
                if (declarationParsers.TryGetValue(token.Value, out result))
                    return result;
            }
            return null;
        }
        public void SelfRegister(Parser parser)
        {
            parser.RegisterStatementParser(TokenType.Identifier, this);
            parser.RegisterStatementParser("Underscore", this);
        }
        
    }
}
