using RoadFlow.Data.MSSQL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class TestController : MyController
	{
		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public ActionResult Index()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public ActionResult CustomForm()
		{
			return CustomForm(null);
		}

		[HttpPost]
		[MyAttribute(CheckApp = false, CheckUrl = false)]
		[ValidateAntiForgeryToken]
		public ActionResult CustomForm(FormCollection coll)
		{
			string text = base.Request.QueryString["instanceid"];
			if (coll != null)
			{
				string text2 = base.Request.Form["Title"];
				string text3 = base.Request.Form["Contents"];
				string empty = string.Empty;
				empty = (text.IsNullOrEmpty() ? "insert into TempTest_CustomForm(Title,Contents) values(@Title,@Contents)" : ("update TempTest_CustomForm set Title=@Title,Contents=@Contents where id=" + text));
				SqlParameter[] parameter = new SqlParameter[2]
				{
					new SqlParameter("@Title", text2),
					new SqlParameter("@Contents", text3)
				};
				int num = new DBHelper().Execute(empty, parameter, true);
				base.ViewBag.title1 = text2;
				base.ViewBag.contents = text3;
				base.ViewBag.script = "$('#instanceid',parent.document).val('" + num + "');$('#customformtitle',parent.document).val('" + text2 + "');parent.flowSaveAndSendIframe(true);";
			}
			else if (!text.IsNullOrEmpty())
			{
				DataTable dataTable = new DBHelper().GetDataTable("select * from TempTest_CustomForm where id=" + text);
				if (dataTable.Rows.Count > 0)
				{
					base.ViewBag.title1 = dataTable.Rows[0]["Title"].ToString();
					base.ViewBag.contents = dataTable.Rows[0]["Contents"].ToString();
				}
			}
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public ActionResult CustomForm1()
		{
			string text = base.Request.QueryString["instanceid"];
			if (!text.IsNullOrEmpty())
			{
				string sql = "select * from TempTest_CustomForm where id=" + text;
				DataTable dataTable = new DBHelper().GetDataTable(sql);
				if (dataTable.Rows.Count > 0)
				{
					base.ViewBag.title1 = dataTable.Rows[0]["Title"].ToString();
					base.ViewBag.contents = dataTable.Rows[0]["Contents"].ToString();
				}
			}
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public string saveCustomForm1()
		{
			string text = base.Request.QueryString["instanceid"];
			string value = base.Request.Form["Title"];
			string value2 = base.Request.Form["Contents"];
			string empty = string.Empty;
			empty = (text.IsNullOrEmpty() ? "insert into TempTest_CustomForm(Title,Contents) values(@Title,@Contents)" : ("update TempTest_CustomForm set Title=@Title,Contents=@Contents where id=" + text));
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@Title", value),
				new SqlParameter("@Contents", value2)
			};
			int num = new DBHelper().Execute(empty, parameter, true);
			return "{\"msg\":\"保存成功\",\"instanceid\":\"" + num + "\"}";
		}
	}
}
