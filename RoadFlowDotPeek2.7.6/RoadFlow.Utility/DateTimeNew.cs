// Decompiled with JetBrains decompiler
// Type: RoadFlow.Utility.DateTimeNew
// Assembly: RoadFlow.Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E4D91F62-39BF-4125-A013-6EDB7CF1B4EC
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Utility.dll

using System;

namespace RoadFlow.Utility
{
  public class DateTimeNew
  {
    public static DateTime Now
    {
      get
      {
        return DateTime.Now;
      }
    }

    public static string ShortDate
    {
      get
      {
        return DateTimeNew.Now.ToString(Config.DateFormat);
      }
    }

    public static string LongDate
    {
      get
      {
        return DateTimeNew.Now.ToString("yyyy年MM月dd日");
      }
    }

    public static string ShortDateTime
    {
      get
      {
        return DateTimeNew.Now.ToString(Config.DateTimeFormat);
      }
    }

    public static string ShortDateTimeS
    {
      get
      {
        return DateTimeNew.Now.ToString(Config.DateTimeFormatS);
      }
    }

    public static string LongDateTime
    {
      get
      {
        return DateTimeNew.Now.ToString("yyyy年MM月dd日 HH时mm分");
      }
    }

    public static string LongDateTimeS
    {
      get
      {
        return DateTimeNew.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
      }
    }

    public static string LongTime
    {
      get
      {
        return DateTimeNew.Now.ToString("HH时mm分");
      }
    }

    public static string ShortTime
    {
      get
      {
        return DateTimeNew.Now.ToString("HH:mm");
      }
    }
  }
}
