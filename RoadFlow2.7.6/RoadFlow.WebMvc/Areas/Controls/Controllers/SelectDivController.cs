// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.Controls.Controllers.SelectDivController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System.Data;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Areas.Controls.Controllers
{
  public class SelectDivController : Controller
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public string GetTitles()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      string str1 = this.Request.QueryString["values"];
      string str2 = this.Request.QueryString["titlefield"];
      string str3 = this.Request.QueryString["pkfield"];
      RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(this.Request.QueryString["applibaryid"].ToGuid(), false);
      if (appLibrary == null)
        return str1;
      RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder().Get(appLibrary.Code.ToGuid());
      if (programBuilder == null)
        return str1;
      RoadFlow.Data.Model.DBConnection dbconn = new RoadFlow.Platform.DBConnection().Get(programBuilder.DBConnID, true);
      if (dbconn == null)
        return str1;
      string sql = "select " + str2 + " from (" + programBuilder.SQL.ReplaceSelectSql().FilterWildcard(RoadFlow.Platform.Users.CurrentUserID.ToString()) + ") gettitletemptable where " + str3 + " in(" + RoadFlow.Utility.Tools.GetSqlInString(str1, true, ",") + ")";
      DataTable dataTable = new RoadFlow.Platform.DBConnection().GetDataTable(dbconn, sql, (IDataParameter[]) null);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        stringBuilder.Append(row[0]);
        stringBuilder.Append(",");
      }
      return stringBuilder.ToString().TrimEnd(',');
    }
  }
}
