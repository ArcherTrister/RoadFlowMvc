// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WeiXinMessage
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class WeiXinMessage
  {
    private IWeiXinMessage dataWeiXinMessage;

    public WeiXinMessage()
    {
      this.dataWeiXinMessage = RoadFlow.Data.Factory.Factory.GetWeiXinMessage();
    }

    public int Add(RoadFlow.Data.Model.WeiXinMessage model)
    {
      return this.dataWeiXinMessage.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WeiXinMessage model)
    {
      return this.dataWeiXinMessage.Update(model);
    }

    public List<RoadFlow.Data.Model.WeiXinMessage> GetAll()
    {
      return this.dataWeiXinMessage.GetAll();
    }

    public RoadFlow.Data.Model.WeiXinMessage Get(Guid id)
    {
      return this.dataWeiXinMessage.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWeiXinMessage.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWeiXinMessage.GetCount();
    }
  }
}
