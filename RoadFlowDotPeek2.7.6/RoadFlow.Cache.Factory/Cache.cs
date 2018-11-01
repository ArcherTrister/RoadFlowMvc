// Decompiled with JetBrains decompiler
// Type: RoadFlow.Cache.Factory.Cache
// Assembly: RoadFlow.Cache.Factory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA97B5ED-C25F-4574-95C5-6FDFCA420E32
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Cache.Factory.dll

using RoadFlow.Cache.Interface;

namespace RoadFlow.Cache.Factory
{
  public class Cache
  {
    public static ICache CreateInstance()
    {
      return new RoadFlow.Cache.InProc.Cache();
    }
  }
}
