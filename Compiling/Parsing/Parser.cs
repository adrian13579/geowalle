using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;
using System.Reflection;
using System.IO;

namespace Compiling.Parsing
{
    public class Parser
    {
        #region InternalVariables
        Token[] _tokens;
        int pointer;
        List<CompilingError> errors;

        Dictionary<string, IInfixExpressionParser> infixExpressionParserValue = new Dictionary<string, IInfixExpressionParser>();
        Dictionary<string, IPrefixExpressionParser> prefixExpressionParserValue = new Dictionary<string, IPrefixExpressionParser>();
        Dictionary<TokenType, IInfixExpressionParser> infixExpressionParserType = new Dictionary<TokenType, IInfixExpressionParser>();
        Dictionary<TokenType, IPrefixExpressionParser> prefixExpressionParserType = new Dictionary<TokenType, IPrefixExpressionParser>();
        Dictionary<string, IStatementParser> prefixStatementParserValue = new Dictionary<string, IStatementParser>();
        Dictionary<TokenType, IStatementParser> prefixStatementParserType = new Dictionary<TokenType, IStatementParser>();
        #endregion

        #region Register
        public void RegisterInfixParser(string tokenValue, IInfixExpressionParser infixParser)
        {
            this.infixExpressionParserValue.Add(tokenValue, infixParser);
        }
        public void RegisterInfixParser(TokenType tokenType, IInfixExpressionParser infixParser)
        {
            this.infixExpressionParserType.Add(tokenType, infixParser);
        }
        public void RegisterPrefixParser(string tokenValue, IPrefixExpressionParser prefixParser)
        {
            this.prefixExpressionParserValue.Add(tokenValue, prefixParser);
        }
        public void RegisterPrefixParser(TokenType tokenType, IPrefixExpressionParser prefixParser)
        {
            this.prefixExpressionParserType.Add(tokenType, prefixParser);
        }
        public void RegisterStatementParser(string tokenValue, IStatementParser prefixParser)
        {
            prefixStatementParserValue.Add(tokenValue, prefixParser);
        }
        public void RegisterStatementParser(TokenType tokenType, IStatementParser prefixParser)
        {
            prefixStatementParserType.Add(tokenType, prefixParser);
        }
        #endregion

        #region Properties
        public List<CompilingError> Errors { get { return errors; } }
        public Token PreviousParsedToken { get { return _tokens[pointer - 1]; } }

        #endregion

        #region Constructor
        public Parser()
        {
            var directory = Directory.GetCurrentDirectory();
            foreach (var file in Directory.GetFiles(directory))
            {
                if (Path.GetExtension(file) != ".exe" && Path.GetExtension(file) != ".dll")
                    continue;
                var assembly = Assembly.LoadFile(file);
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract && typeof(IMiniParser).IsAssignableFrom(type))
                    {
                        Activator.CreateInstance(type, this);
                    }
                }
            }
        }
        #endregion

        #region Parsing
        public ProgramNode ParseProgram(IEnumerable<Token> tokens, List<CompilingError> errors)
        {
            this.errors = errors;
            _tokens = tokens.ToArray();
            pointer = 0;

            List<Statement> instructions = new List<Statement>();
            while (pointer < _tokens.Length )
            {
                Statement instruction = ParseStatement();
                if (instruction == null)
                {
                    Token token = Consume();
                    Errors.Add(new CompilingError(PreviousParsedToken.Location, ErrorCode.Unknown, "No se pudo parsear la instruccion"));
                }
                else instructions.Add(instruction);
            }
            return new ProgramNode(instructions);
        }
        public Statement ParseStatement()
        {
            Token token = LookAhead(0);
            IStatementParser statementParser = GetStatementParser(token);
            if (statementParser != null)
            {
                return statementParser.Parse(this);
            }
            return null;
        }
        public Expression ParseExpression(int precedence = 0)
        {
            Token token = Consume();
            IPrefixExpressionParser prefix = GetPrefixExpressionParser(token);
            if (prefix == null)
            {
                errors.Add(new CompilingError(PreviousParsedToken.Location, ErrorCode.Unknown, "Se esperaba un operador prefijo"));
                return null;
            }
            Expression left = prefix.Parse(this, token);
            while (precedence < GetPrecedence())
            {
                token = Consume();
                if (token == null) break;
                IInfixExpressionParser infix = GetInfixExpressionParser(token);
                left = infix.Parse(this, left, token);
            }
            return left;
        }
        #endregion

        #region AuxiliarMethods
        public void ConsumeExpectedToken(string expected)
        {
            Token token = Consume();
            if (token == null || token.Value != expected)
            {
                errors.Add(new CompilingError(PreviousParsedToken.Location, ErrorCode.Expected, "Falta el  " + expected));
                ReStartParsingTo(token);
            }
        }
        public bool Match(string expected)
        {
            if (_tokens[pointer].Value == expected)
            {
                Consume();
                return true;
            }
            return false;
        }
        public Token LookAhead(int n)
        {
            n += pointer;
            if (n >= _tokens.Length)
                return null;
            return _tokens[n];
        }
        public void ReStartParsingTo(Token token)
        {
            for (int i = 0; i < _tokens.Length; i++)
            {
                if (_tokens[i] == token)
                {
                    pointer = i;
                    return;
                }
            }
        }
        public Token Consume()
        {
            if (pointer == _tokens.Length)
                return null;
            return _tokens[pointer++];
        }
        private int GetPrecedence()
        {
            IInfixExpressionParser parser = GetInfixExpressionParser(LookAhead(0));
            if (parser != null)
                return parser.GetPrecedence();
            return 0;
        }
        private IPrefixExpressionParser GetPrefixExpressionParser(Token token)
        {
            if (token != null)
            {
                IPrefixExpressionParser result;
                if (prefixExpressionParserValue.TryGetValue(token.Value, out result))
                    return result;

                if (prefixExpressionParserType.TryGetValue(token.Type, out result))
                    return result;
            }
            return null;
        }
        private IInfixExpressionParser GetInfixExpressionParser(Token token)
        {
            if (token != null)
            {
                IInfixExpressionParser result;
                if (infixExpressionParserValue.TryGetValue(token.Value, out result))
                    return result;

                if (infixExpressionParserType.TryGetValue(token.Type, out result))
                    return result;
            }
            return null;
        }
        private IStatementParser GetStatementParser(Token token)
        {
            if (token != null)
            {
                IStatementParser result;
                if (prefixStatementParserValue.TryGetValue(token.Value, out result))
                    return result;

                if (prefixStatementParserType.TryGetValue(token.Type, out result))
                    return result;
            }
            return null;
        }

        #endregion
    }
}
