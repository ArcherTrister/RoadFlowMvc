// Decompiled with JetBrains decompiler
// Type: WebMvc.Common.CustomFormSave
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowExecute;
using RoadFlow.Data.MSSQL;
using System.Web;

namespace WebMvc.Common
{
  public class CustomFormSave
  {
    public static object GetJson(WorkFlowCustomEventParams eventParams)
    {
      return (object) new DBHelper().GetDataTable("select * from users");
    }

    public static string QianShi(WorkFlowCustomEventParams eventParams)
    {
      RoadFlow.Platform.Log.Add("获取值测试", HttpContext.Current.Request["TempTest.Title"] + "--", RoadFlow.Platform.Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
      return "";
    }

    public static string GetMembers(WorkFlowCustomEventParams eventParams)
    {
      return "u_EB03262C-AB60-4BC6-A4C0-96E66A4229FE,u_8086D01F-7AE3-402E-B543-D34F1059F79A";
    }

    public static Execute SubFlowActivationBefore(WorkFlowCustomEventParams eventParams)
    {
      Execute execute = new Execute();
      RoadFlow.Platform.Log.Add("执行了子流程激活前事件", "", RoadFlow.Platform.Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
      return execute;
    }

    public static void SubFlowCompletedBefore(WorkFlowCustomEventParams eventParams)
    {
      RoadFlow.Platform.Log.Add("执行了子流程结束后事件", "", RoadFlow.Platform.Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
    }
  }
}
