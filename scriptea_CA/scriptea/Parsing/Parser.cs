﻿using System;
using scriptea.Lexical;

namespace scriptea.Parsing
{
    public  class Parser
    {
        private Lexer _lexer;
        private Token _currenToken;
        public INTerminal StartINTerminal;

        internal Token CurrenToken { get { return _currenToken; } }

        internal void NextToken()
        {
            _currenToken = _lexer.GetNextToken();
        }

        public Parser(Lexer lexer)
        {
            _lexer = lexer;
            _currenToken = _lexer.GetNextToken();
        }

        public void Parse()
        {
            StartINTerminal.Process(this);
            if (_currenToken.Type != TokenType.Eof)
            {
                throw  new ParserException("This was expected EOF");
            }
        }
    }
}