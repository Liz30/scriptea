﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateGreaterThan:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = TokenType.OpGreaterEqualThan, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
            else if (pInput.CurrentSymbol == '>')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateRightShift1().ProcessState(pInput,pLexeme);
            }
            else
            {
                return new Token { Type = TokenType.OpGreaterThan, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
        }
    }
}
