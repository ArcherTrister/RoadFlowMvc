// Decompiled with JetBrains decompiler
// Type: RoadFlow.Cache.Interface.ICache
// Assembly: RoadFlow.Cache.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 23C0B905-FDB1-4FE2-A160-E8C7015D053A
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Cache.Interface.dll

using System;

namespace RoadFlow.Cache.Interface
{
  public interface ICache
  {
    bool Insert(string key, object obj);

    bool Insert(string key, object obj, DateTime expiry);

    object Get(string key);

    bool Remove(string key);

    void RemoveAll();
  }
}
