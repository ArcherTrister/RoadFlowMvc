// Decompiled with JetBrains decompiler
// Type: LitJson.JsonException
// Assembly: LitJSON, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD8BB339-7767-43EF-A04A-8D9AAFD8D90B
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\LitJSON.dll

using System;

namespace LitJson
{
  public class JsonException : ApplicationException
  {
    public JsonException()
    {
    }

    internal JsonException(ParserToken token)
      : base(string.Format("Invalid token '{0}' in input string", (object) token))
    {
    }

    internal JsonException(ParserToken token, Exception inner_exception)
      : base(string.Format("Invalid token '{0}' in input string", (object) token), inner_exception)
    {
    }

    internal JsonException(int c)
      : base(string.Format("Invalid character '{0}' in input string", (object) (char) c))
    {
    }

    internal JsonException(int c, Exception inner_exception)
      : base(string.Format("Invalid character '{0}' in input string", (object) (char) c), inner_exception)
    {
    }

    public JsonException(string message)
      : base(message)
    {
    }

    public JsonException(string message, Exception inner_exception)
      : base(message, inner_exception)
    {
    }
  }
}
