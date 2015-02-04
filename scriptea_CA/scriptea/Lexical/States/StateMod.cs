﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateMod:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = TokenType.OpAssigMod, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
            else
            {
                return new Token { Type = TokenType.OpMod, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
        }
    }
}
