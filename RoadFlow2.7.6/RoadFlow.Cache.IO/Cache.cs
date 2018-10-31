// Decompiled with JetBrains decompiler
// Type: RoadFlow.Cache.IO.Opation
// Assembly: RoadFlow.Cache.IO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F28456CD-2A0A-4151-8D92-E958C1ADEE82
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Cache.IO.dll

using System;

namespace RoadFlow.Cache.IO
{
  public class Opation
  {
    public static bool Insert(string key, object obj)
    {
      return RoadFlow.Cache.Factory.Cache.CreateInstance().Insert(key, obj);
    }

    public static bool Set(string key, object obj)
    {
      return Opation.Insert(key, obj);
    }

    public static bool Insert(string key, object obj, DateTime expiry)
    {
      return RoadFlow.Cache.Factory.Cache.CreateInstance().Insert(key, obj, expiry);
    }

    public static bool Set(string key, object obj, DateTime expiry)
    {
      return Opation.Insert(key, obj, expiry);
    }

    public static object Get(string key)
    {
      try
      {
        return RoadFlow.Cache.Factory.Cache.CreateInstance().Get(key);
      }
      catch
      {
        return (object) null;
      }
    }

    public static bool Remove(string key)
    {
      return RoadFlow.Cache.Factory.Cache.CreateInstance().Remove(key);
    }

    public static void RemoveAll()
    {
      RoadFlow.Cache.Factory.Cache.CreateInstance().RemoveAll();
    }
  }
}
