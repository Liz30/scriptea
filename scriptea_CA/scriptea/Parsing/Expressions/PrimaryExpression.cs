﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public  class PrimaryExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmRightParent)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected ) ");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftBracket)
            {
                parser.NextToken();
                new ExpressionOpt().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmRightBracket)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected ]");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.LitInteger)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.LitFloat)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.LitString)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.LitBool)
            {
                parser.NextToken();
            }
            else if(parser.CurrenToken.Type == TokenType.KwNull)
            {
                throw  new ParserException("This was expected (, [, lit. int,lit. float, lit. bool or null");
            }
        }
    }
}
