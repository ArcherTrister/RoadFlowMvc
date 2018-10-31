// Decompiled with JetBrains decompiler
// Type: WebMvc.Common.HomePage
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Data.MSSQL;
using RoadFlow.Platform;
using System.Data;
using System.Text;

namespace WebMvc.Common
{
  public class HomePage
  {
    public static string GetShortMessageList()
    {
      DataTable dataTable = new DBHelper().GetDataTable("select top 5 id,title,contents,sendusername,sendtime from ShortMessage where ReceiveUserID='" + (object) RoadFlow.Platform.Users.CurrentUserID + "' order by sendtime desc");
      StringBuilder stringBuilder = new StringBuilder();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        stringBuilder.Append("<div style='margin:10px 0 5px 0;'>");
        stringBuilder.Append("<a href=\"javascript:show('" + row["ID"].ToString() + "');\">" + row["title"].ToString() + "</a>");
        stringBuilder.Append("</div>");
        stringBuilder.Append("<div style='color:#999; padding:3px 0 5px 0;border-bottom:1px dotted #e8e8e8;'>");
        stringBuilder.Append("<span>发送人：" + row["sendusername"] + "</span>");
        stringBuilder.Append("<span style='margin:0 6px;'>|</span>");
        stringBuilder.Append("<span>时间：" + row["sendtime"].ToString().ToDateTimeStringS() + "</span>");
        stringBuilder.Append("</div>");
      }
      stringBuilder.Append("<script>");
      stringBuilder.Append("function show(id){new RoadUI.Window().open({ url: RoadUI.Core.rooturl() + '/ShortMessage/Show?id=' + id, width: 900, height: 500, title: '查看消息' });}");
      stringBuilder.Append("</script>");
      return stringBuilder.ToString();
    }

    public static string GetOnlineUsersCount()
    {
      return new OnlineUsers().GetAll().Count.ToString();
    }
  }
}
