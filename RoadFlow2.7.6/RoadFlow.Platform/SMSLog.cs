// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.SMSLog
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class SMSLog
  {
    private static ISMSLog dataSMSLog = RoadFlow.Data.Factory.Factory.GetSMSLog();

    public int Add(RoadFlow.Data.Model.SMSLog model)
    {
      return SMSLog.dataSMSLog.Add(model);
    }

    public int Update(RoadFlow.Data.Model.SMSLog model)
    {
      return SMSLog.dataSMSLog.Update(model);
    }

    public List<RoadFlow.Data.Model.SMSLog> GetAll()
    {
      return SMSLog.dataSMSLog.GetAll();
    }

    public RoadFlow.Data.Model.SMSLog Get(Guid id)
    {
      return SMSLog.dataSMSLog.Get(id);
    }

    public int Delete(Guid id)
    {
      return SMSLog.dataSMSLog.Delete(id);
    }

    public long GetCount()
    {
      return SMSLog.dataSMSLog.GetCount();
    }

    private static void add(RoadFlow.Data.Model.SMSLog model)
    {
      SMSLog.dataSMSLog.Add(model);
    }

    public static void AddSync(RoadFlow.Data.Model.SMSLog model)
    {
      new SMSLog.dgWriteLog(SMSLog.add).BeginInvoke(model, (AsyncCallback) null, (object) null);
    }

    public static void AddSync(string mobileNumber, string contents, int status, Guid sendUserID, string sendUserName = "", string note = "")
    {
      SMSLog.AddSync(new RoadFlow.Data.Model.SMSLog()
      {
        Contents = contents,
        ID = Guid.NewGuid(),
        MobileNumber = mobileNumber,
        SendTime = DateTimeNew.Now,
        SendUserID = new Guid?(sendUserID.IsEmptyGuid() ? Users.CurrentUserID : sendUserID),
        SendUserName = sendUserName.IsNullOrEmpty() ? Users.CurrentUserName : sendUserName,
        Status = status,
        Note = note
      });
    }

    public static string SendSMS(string mobileNumber, string contents)
    {
      if (mobileNumber.IsNullOrEmpty() || contents.IsNullOrEmpty())
        return "";
      string str = mobileNumber;
      char[] chArray = new char[1]{ ',' };
      foreach (string mobileNumber1 in str.Split(chArray))
        SMSLog.AddSync(mobileNumber1, contents, 1, Guid.Empty, "", "");
      return "";
    }

    private delegate void dgWriteLog(RoadFlow.Data.Model.SMSLog smsLog);
  }
}
