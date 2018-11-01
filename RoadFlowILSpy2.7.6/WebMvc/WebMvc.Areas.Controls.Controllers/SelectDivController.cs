using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System.Data;
using System.Text;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Areas.Controls.Controllers
{
	public class SelectDivController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public string GetTitles()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			string text = base.Request.QueryString["values"];
			string text2 = base.Request.QueryString["titlefield"];
			string text3 = base.Request.QueryString["pkfield"];
			string str = base.Request.QueryString["applibaryid"];
			RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(str.ToGuid());
			if (appLibrary == null)
			{
				return text;
			}
			RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder().Get(appLibrary.Code.ToGuid());
			if (programBuilder == null)
			{
				return text;
			}
			RoadFlow.Data.Model.DBConnection dBConnection = new RoadFlow.Platform.DBConnection().Get(programBuilder.DBConnID);
			if (dBConnection == null)
			{
				return text;
			}
			string sql = "select " + text2 + " from (" + programBuilder.SQL.ReplaceSelectSql().FilterWildcard(RoadFlow.Platform.Users.CurrentUserID.ToString()) + ") gettitletemptable where " + text3 + " in(" + RoadFlow.Utility.Tools.GetSqlInString(text) + ")";
			DataTable dataTable = new RoadFlow.Platform.DBConnection().GetDataTable(dBConnection, sql);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (DataRow row in dataTable.Rows)
			{
				stringBuilder.Append(row[0]);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}
	}
}
