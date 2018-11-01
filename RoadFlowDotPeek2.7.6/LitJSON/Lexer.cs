﻿// Decompiled with JetBrains decompiler
// Type: LitJson.Lexer
// Assembly: LitJSON, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD8BB339-7767-43EF-A04A-8D9AAFD8D90B
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\LitJSON.dll

using System;
using System.IO;
using System.Text;

namespace LitJson
{
  internal class Lexer
  {
    private static int[] fsm_return_table;
    private static Lexer.StateHandler[] fsm_handler_table;
    private bool allow_comments;
    private bool allow_single_quoted_strings;
    private bool end_of_input;
    private FsmContext fsm_context;
    private int input_buffer;
    private int input_char;
    private TextReader reader;
    private int state;
    private StringBuilder string_buffer;
    private string string_value;
    private int token;
    private int unichar;

    public bool AllowComments
    {
      get
      {
        return this.allow_comments;
      }
      set
      {
        this.allow_comments = value;
      }
    }

    public bool AllowSingleQuotedStrings
    {
      get
      {
        return this.allow_single_quoted_strings;
      }
      set
      {
        this.allow_single_quoted_strings = value;
      }
    }

    public bool EndOfInput
    {
      get
      {
        return this.end_of_input;
      }
    }

    public int Token
    {
      get
      {
        return this.token;
      }
    }

    public string StringValue
    {
      get
      {
        return this.string_value;
      }
    }

    static Lexer()
    {
      Lexer.PopulateFsmTables();
    }

    public Lexer(TextReader reader)
    {
      this.allow_comments = true;
      this.allow_single_quoted_strings = true;
      this.input_buffer = 0;
      this.string_buffer = new StringBuilder(128);
      this.state = 1;
      this.end_of_input = false;
      this.reader = reader;
      this.fsm_context = new FsmContext();
      this.fsm_context.L = this;
    }

    private static int HexValue(int digit)
    {
      switch (digit)
      {
        case 65:
        case 97:
          return 10;
        case 66:
        case 98:
          return 11;
        case 67:
        case 99:
          return 12;
        case 68:
        case 100:
          return 13;
        case 69:
        case 101:
          return 14;
        case 70:
        case 102:
          return 15;
        default:
          return digit - 48;
      }
    }

    private static void PopulateFsmTables()
    {
      Lexer.fsm_handler_table = new Lexer.StateHandler[28]
      {
        new Lexer.StateHandler(Lexer.State1),
        new Lexer.StateHandler(Lexer.State2),
        new Lexer.StateHandler(Lexer.State3),
        new Lexer.StateHandler(Lexer.State4),
        new Lexer.StateHandler(Lexer.State5),
        new Lexer.StateHandler(Lexer.State6),
        new Lexer.StateHandler(Lexer.State7),
        new Lexer.StateHandler(Lexer.State8),
        new Lexer.StateHandler(Lexer.State9),
        new Lexer.StateHandler(Lexer.State10),
        new Lexer.StateHandler(Lexer.State11),
        new Lexer.StateHandler(Lexer.State12),
        new Lexer.StateHandler(Lexer.State13),
        new Lexer.StateHandler(Lexer.State14),
        new Lexer.StateHandler(Lexer.State15),
        new Lexer.StateHandler(Lexer.State16),
        new Lexer.StateHandler(Lexer.State17),
        new Lexer.StateHandler(Lexer.State18),
        new Lexer.StateHandler(Lexer.State19),
        new Lexer.StateHandler(Lexer.State20),
        new Lexer.StateHandler(Lexer.State21),
        new Lexer.StateHandler(Lexer.State22),
        new Lexer.StateHandler(Lexer.State23),
        new Lexer.StateHandler(Lexer.State24),
        new Lexer.StateHandler(Lexer.State25),
        new Lexer.StateHandler(Lexer.State26),
        new Lexer.StateHandler(Lexer.State27),
        new Lexer.StateHandler(Lexer.State28)
      };
      Lexer.fsm_return_table = new int[28]
      {
        65542,
        0,
        65537,
        65537,
        0,
        65537,
        0,
        65537,
        0,
        0,
        65538,
        0,
        0,
        0,
        65539,
        0,
        0,
        65540,
        65541,
        65542,
        0,
        0,
        65541,
        65542,
        0,
        0,
        0,
        0
      };
    }

    private static char ProcessEscChar(int esc_char)
    {
      switch (esc_char)
      {
        case 34:
        case 39:
        case 47:
        case 92:
          return Convert.ToChar(esc_char);
        case 98:
          return '\b';
        case 102:
          return '\f';
        case 110:
          return '\n';
        case 114:
          return '\r';
        case 116:
          return '\t';
        default:
          return '?';
      }
    }

    private static bool State1(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        if (ctx.L.input_char != 32 && (ctx.L.input_char < 9 || ctx.L.input_char > 13))
        {
          if (ctx.L.input_char >= 49 && ctx.L.input_char <= 57)
          {
            ctx.L.string_buffer.Append((char) ctx.L.input_char);
            ctx.NextState = 3;
            return true;
          }
          switch (ctx.L.input_char)
          {
            case 34:
              ctx.NextState = 19;
              ctx.Return = true;
              return true;
            case 39:
              if (!ctx.L.allow_single_quoted_strings)
                return false;
              ctx.L.input_char = 34;
              ctx.NextState = 23;
              ctx.Return = true;
              return true;
            case 44:
            case 58:
            case 91:
            case 93:
            case 123:
            case 125:
              ctx.NextState = 1;
              ctx.Return = true;
              return true;
            case 45:
              ctx.L.string_buffer.Append((char) ctx.L.input_char);
              ctx.NextState = 2;
              return true;
            case 47:
              if (!ctx.L.allow_comments)
                return false;
              ctx.NextState = 25;
              return true;
            case 48:
              ctx.L.string_buffer.Append((char) ctx.L.input_char);
              ctx.NextState = 4;
              return true;
            case 102:
              ctx.NextState = 12;
              return true;
            case 110:
              ctx.NextState = 16;
              return true;
            case 116:
              ctx.NextState = 9;
              return true;
            default:
              return false;
          }
        }
      }
      return true;
    }

    private static bool State2(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char >= 49 && ctx.L.input_char <= 57)
      {
        ctx.L.string_buffer.Append((char) ctx.L.input_char);
        ctx.NextState = 3;
        return true;
      }
      if (ctx.L.input_char != 48)
        return false;
      ctx.L.string_buffer.Append((char) ctx.L.input_char);
      ctx.NextState = 4;
      return true;
    }

    private static bool State3(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
        {
          ctx.L.string_buffer.Append((char) ctx.L.input_char);
        }
        else
        {
          if (ctx.L.input_char == 32 || ctx.L.input_char >= 9 && ctx.L.input_char <= 13)
          {
            ctx.Return = true;
            ctx.NextState = 1;
            return true;
          }
          switch (ctx.L.input_char)
          {
            case 44:
            case 93:
            case 125:
              ctx.L.UngetChar();
              ctx.Return = true;
              ctx.NextState = 1;
              return true;
            case 46:
              ctx.L.string_buffer.Append((char) ctx.L.input_char);
              ctx.NextState = 5;
              return true;
            case 69:
            case 101:
              ctx.L.string_buffer.Append((char) ctx.L.input_char);
              ctx.NextState = 7;
              return true;
            default:
              return false;
          }
        }
      }
      return true;
    }

    private static bool State4(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char == 32 || ctx.L.input_char >= 9 && ctx.L.input_char <= 13)
      {
        ctx.Return = true;
        ctx.NextState = 1;
        return true;
      }
      switch (ctx.L.input_char)
      {
        case 44:
        case 93:
        case 125:
          ctx.L.UngetChar();
          ctx.Return = true;
          ctx.NextState = 1;
          return true;
        case 46:
          ctx.L.string_buffer.Append((char) ctx.L.input_char);
          ctx.NextState = 5;
          return true;
        case 69:
        case 101:
          ctx.L.string_buffer.Append((char) ctx.L.input_char);
          ctx.NextState = 7;
          return true;
        default:
          return false;
      }
    }

    private static bool State5(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char < 48 || ctx.L.input_char > 57)
        return false;
      ctx.L.string_buffer.Append((char) ctx.L.input_char);
      ctx.NextState = 6;
      return true;
    }

    private static bool State6(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
        {
          ctx.L.string_buffer.Append((char) ctx.L.input_char);
        }
        else
        {
          if (ctx.L.input_char == 32 || ctx.L.input_char >= 9 && ctx.L.input_char <= 13)
          {
            ctx.Return = true;
            ctx.NextState = 1;
            return true;
          }
          switch (ctx.L.input_char)
          {
            case 44:
            case 93:
            case 125:
              ctx.L.UngetChar();
              ctx.Return = true;
              ctx.NextState = 1;
              return true;
            case 69:
            case 101:
              ctx.L.string_buffer.Append((char) ctx.L.input_char);
              ctx.NextState = 7;
              return true;
            default:
              return false;
          }
        }
      }
      return true;
    }

    private static bool State7(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
      {
        ctx.L.string_buffer.Append((char) ctx.L.input_char);
        ctx.NextState = 8;
        return true;
      }
      switch (ctx.L.input_char)
      {
        case 43:
        case 45:
          ctx.L.string_buffer.Append((char) ctx.L.input_char);
          ctx.NextState = 8;
          return true;
        default:
          return false;
      }
    }

    private static bool State8(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
        {
          ctx.L.string_buffer.Append((char) ctx.L.input_char);
        }
        else
        {
          if (ctx.L.input_char == 32 || ctx.L.input_char >= 9 && ctx.L.input_char <= 13)
          {
            ctx.Return = true;
            ctx.NextState = 1;
            return true;
          }
          switch (ctx.L.input_char)
          {
            case 44:
            case 93:
            case 125:
              ctx.L.UngetChar();
              ctx.Return = true;
              ctx.NextState = 1;
              return true;
            default:
              return false;
          }
        }
      }
      return true;
    }

    private static bool State9(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 114)
        return false;
      ctx.NextState = 10;
      return true;
    }

    private static bool State10(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 117)
        return false;
      ctx.NextState = 11;
      return true;
    }

    private static bool State11(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 101)
        return false;
      ctx.Return = true;
      ctx.NextState = 1;
      return true;
    }

    private static bool State12(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 97)
        return false;
      ctx.NextState = 13;
      return true;
    }

    private static bool State13(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 108)
        return false;
      ctx.NextState = 14;
      return true;
    }

    private static bool State14(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 115)
        return false;
      ctx.NextState = 15;
      return true;
    }

    private static bool State15(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 101)
        return false;
      ctx.Return = true;
      ctx.NextState = 1;
      return true;
    }

    private static bool State16(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 117)
        return false;
      ctx.NextState = 17;
      return true;
    }

    private static bool State17(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 108)
        return false;
      ctx.NextState = 18;
      return true;
    }

    private static bool State18(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 108)
        return false;
      ctx.Return = true;
      ctx.NextState = 1;
      return true;
    }

    private static bool State19(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        switch (ctx.L.input_char)
        {
          case 34:
            ctx.L.UngetChar();
            ctx.Return = true;
            ctx.NextState = 20;
            return true;
          case 92:
            ctx.StateStack = 19;
            ctx.NextState = 21;
            return true;
          default:
            ctx.L.string_buffer.Append((char) ctx.L.input_char);
            continue;
        }
      }
      return true;
    }

    private static bool State20(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 34)
        return false;
      ctx.Return = true;
      ctx.NextState = 1;
      return true;
    }

    private static bool State21(FsmContext ctx)
    {
      ctx.L.GetChar();
      switch (ctx.L.input_char)
      {
        case 34:
        case 39:
        case 47:
        case 92:
        case 98:
        case 102:
        case 110:
        case 114:
        case 116:
          ctx.L.string_buffer.Append(Lexer.ProcessEscChar(ctx.L.input_char));
          ctx.NextState = ctx.StateStack;
          return true;
        case 117:
          ctx.NextState = 22;
          return true;
        default:
          return false;
      }
    }

    private static bool State22(FsmContext ctx)
    {
      int num1 = 0;
      int num2 = 4096;
      ctx.L.unichar = 0;
      while (ctx.L.GetChar())
      {
        if ((ctx.L.input_char < 48 || ctx.L.input_char > 57) && (ctx.L.input_char < 65 || ctx.L.input_char > 70) && (ctx.L.input_char < 97 || ctx.L.input_char > 102))
          return false;
        ctx.L.unichar += Lexer.HexValue(ctx.L.input_char) * num2;
        ++num1;
        num2 /= 16;
        if (num1 == 4)
        {
          ctx.L.string_buffer.Append(Convert.ToChar(ctx.L.unichar));
          ctx.NextState = ctx.StateStack;
          return true;
        }
      }
      return true;
    }

    private static bool State23(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        switch (ctx.L.input_char)
        {
          case 39:
            ctx.L.UngetChar();
            ctx.Return = true;
            ctx.NextState = 24;
            return true;
          case 92:
            ctx.StateStack = 23;
            ctx.NextState = 21;
            return true;
          default:
            ctx.L.string_buffer.Append((char) ctx.L.input_char);
            continue;
        }
      }
      return true;
    }

    private static bool State24(FsmContext ctx)
    {
      ctx.L.GetChar();
      if (ctx.L.input_char != 39)
        return false;
      ctx.L.input_char = 34;
      ctx.Return = true;
      ctx.NextState = 1;
      return true;
    }

    private static bool State25(FsmContext ctx)
    {
      ctx.L.GetChar();
      switch (ctx.L.input_char)
      {
        case 42:
          ctx.NextState = 27;
          return true;
        case 47:
          ctx.NextState = 26;
          return true;
        default:
          return false;
      }
    }

    private static bool State26(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        if (ctx.L.input_char == 10)
        {
          ctx.NextState = 1;
          return true;
        }
      }
      return true;
    }

    private static bool State27(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        if (ctx.L.input_char == 42)
        {
          ctx.NextState = 28;
          return true;
        }
      }
      return true;
    }

    private static bool State28(FsmContext ctx)
    {
      while (ctx.L.GetChar())
      {
        if (ctx.L.input_char != 42)
        {
          if (ctx.L.input_char == 47)
          {
            ctx.NextState = 1;
            return true;
          }
          ctx.NextState = 27;
          return true;
        }
      }
      return true;
    }

    private bool GetChar()
    {
      if ((this.input_char = this.NextChar()) != -1)
        return true;
      this.end_of_input = true;
      return false;
    }

    private int NextChar()
    {
      if (this.input_buffer == 0)
        return this.reader.Read();
      int inputBuffer = this.input_buffer;
      this.input_buffer = 0;
      return inputBuffer;
    }

    public bool NextToken()
    {
      this.fsm_context.Return = false;
      for (; Lexer.fsm_handler_table[this.state - 1](this.fsm_context); this.state = this.fsm_context.NextState)
      {
        if (this.end_of_input)
          return false;
        if (this.fsm_context.Return)
        {
          this.string_value = this.string_buffer.ToString();
          this.string_buffer.Remove(0, this.string_buffer.Length);
          this.token = Lexer.fsm_return_table[this.state - 1];
          if (this.token == 65542)
            this.token = this.input_char;
          this.state = this.fsm_context.NextState;
          return true;
        }
      }
      throw new JsonException(this.input_char);
    }

    private void UngetChar()
    {
      this.input_buffer = this.input_char;
    }

    private delegate bool StateHandler(FsmContext ctx);
  }
}
