﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiling.AST;

namespace Compiling.Parsing
{
    public class SamplesParser : IPrefixExpressionParser
    {
        public int GetPrecedence()
        {
            return Precedence.Call;
        }

        public Expression Parse(Parser parser, Token token)
        {
            parser.ConsumeExpectedToken("OpenBracket");
            parser.ConsumeExpectedToken("ClosedBracket");
            return new Samples(token.Location); 
        }
        public SamplesParser(Parser parser)
        {
            SelfRegister(parser);
        }
        public void SelfRegister(Parser parser)
        {
            parser.RegisterPrefixParser("samples", this);
        }
    }
}
