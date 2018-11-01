using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class MenuController : MyController
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Empty()
		{
			return View();
		}

		public ActionResult Tree()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public string Tree1()
		{
			DataTable allDataTable = new RoadFlow.Platform.Menu().GetAllDataTable();
			if (allDataTable.Rows.Count == 0)
			{
				return "[]";
			}
			DataRow[] array = allDataTable.Select("ParentID='" + Guid.Empty.ToString() + "'");
			if (array.Length == 0)
			{
				return "[]";
			}
			DataRow[] array2 = allDataTable.Select("ParentID='" + array[0]["ID"].ToString() + "'");
			StringBuilder stringBuilder = new StringBuilder("[", 1000);
			DataRow dataRow = array[0];
			string text = dataRow["AppIco"].ToString();
			if (text.IsNullOrEmpty())
			{
				text = dataRow["Ico"].ToString();
			}
			stringBuilder.Append("{");
			stringBuilder.AppendFormat("\"id\":\"{0}\",", dataRow["ID"]);
			stringBuilder.AppendFormat("\"title\":\"{0}\",", dataRow["Title"]);
			stringBuilder.AppendFormat("\"ico\":\"{0}\",", text);
			stringBuilder.AppendFormat("\"link\":\"{0}\",", dataRow["Address"]);
			stringBuilder.AppendFormat("\"type\":\"{0}\",", "0");
			stringBuilder.AppendFormat("\"model\":\"{0}\",", dataRow["OpenMode"]);
			stringBuilder.AppendFormat("\"width\":\"{0}\",", dataRow["Width"]);
			stringBuilder.AppendFormat("\"height\":\"{0}\",", dataRow["Height"]);
			stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (array2.Length != 0) ? "1" : "0");
			stringBuilder.AppendFormat("\"childs\":[");
			for (int i = 0; i < array2.Length; i++)
			{
				DataRow dataRow2 = array2[i];
				string text2 = dataRow2["AppIco"].ToString();
				if (text2.IsNullOrEmpty())
				{
					text2 = dataRow2["Ico"].ToString();
				}
				DataRow[] array3 = allDataTable.Select("ParentID='" + dataRow2["ID"].ToString() + "'");
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", dataRow2["ID"]);
				stringBuilder.AppendFormat("\"title\":\"{0}\",", dataRow2["Title"]);
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", text2);
				stringBuilder.AppendFormat("\"link\":\"{0}\",", dataRow2["Address"]);
				stringBuilder.AppendFormat("\"type\":\"{0}\",", "0");
				stringBuilder.AppendFormat("\"model\":\"{0}\",", dataRow2["OpenMode"]);
				stringBuilder.AppendFormat("\"width\":\"{0}\",", dataRow2["Width"]);
				stringBuilder.AppendFormat("\"height\":\"{0}\",", dataRow2["Height"]);
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (array3.Length != 0) ? "1" : "0");
				stringBuilder.AppendFormat("\"childs\":[");
				stringBuilder.Append("]");
				stringBuilder.Append("}");
				if (i < array2.Length - 1)
				{
					stringBuilder.Append(",");
				}
			}
			stringBuilder.Append("]");
			stringBuilder.Append("}");
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		[MyAttribute(CheckApp = false)]
		public string TreeRefresh()
		{
			string text = base.Request["refreshid"];
			if (!text.IsGuid())
			{
				return "[]";
			}
			RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
			DataRow[] array = menu.GetAllDataTable().Select("ParentID='" + text + "'");
			StringBuilder stringBuilder = new StringBuilder("[", array.Length * 50);
			int num = array.Length;
			int num2 = 0;
			DataRow[] array2 = array;
			foreach (DataRow dataRow in array2)
			{
				string text2 = dataRow["AppIco"].ToString();
				if (text2.IsNullOrEmpty())
				{
					text2 = dataRow["Ico"].ToString();
				}
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", dataRow["ID"]);
				stringBuilder.AppendFormat("\"title\":\"{0}\",", dataRow["Title"]);
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", text2);
				stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"type\":\"{0}\",", "0");
				stringBuilder.AppendFormat("\"model\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"width\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"height\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", menu.HasChild(dataRow["ID"].ToString().ToGuid()) ? "1" : "0");
				stringBuilder.AppendFormat("\"childs\":[");
				stringBuilder.Append("]");
				stringBuilder.Append("}");
				if (num2++ < num - 1)
				{
					stringBuilder.Append(",");
				}
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		public ActionResult Body()
		{
			return Body(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Body(FormCollection collection)
		{
			RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
			RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
			RoadFlow.Data.Model.Menu menu2 = null;
			string str = base.Request.QueryString["id"];
			string empty = string.Empty;
			string value = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			Guid test;
			if (str.IsGuid(out test))
			{
				menu2 = menu.Get(test);
			}
			if (!base.Request.Form["Save"].IsNullOrEmpty())
			{
				empty = base.Request.Form["Name"];
				value = base.Request.Form["Type"];
				empty2 = base.Request.Form["AppID"];
				empty3 = base.Request.Form["Params"];
				empty4 = base.Request.Form["Ico"];
				empty5 = base.Request.Form["IcoColor"];
				string oldXML = menu2.Serialize();
				menu2.Title = empty.Trim();
				if (empty2.IsGuid())
				{
					menu2.AppLibraryID = empty2.ToGuid();
				}
				else
				{
					menu2.AppLibraryID = null;
				}
				menu2.Params = (empty3.IsNullOrEmpty() ? null : empty3.Trim());
				if (!empty4.IsNullOrEmpty())
				{
					menu2.Ico = empty4;
				}
				else
				{
					menu2.Ico = null;
				}
				if (!empty5.IsNullOrEmpty())
				{
					menu2.IcoColor = empty5;
				}
				else
				{
					menu2.IcoColor = null;
				}
				menu.Update(menu2);
				RoadFlow.Platform.Log.Add("修改了菜单", "", RoadFlow.Platform.Log.Types.菜单权限, oldXML, menu2.Serialize());
				string str2 = (menu2.ParentID == Guid.Empty) ? menu2.ID.ToString() : menu2.ParentID.ToString();
				base.ViewBag.Script = "parent.frames[0].reLoad('" + str2 + "');alert('保存成功!');";
				menu.ClearAllDataTableCache();
			}
			if (!base.Request.Form["Delete"].IsNullOrEmpty())
			{
				RoadFlow.Platform.Log.Add("删除了菜单及其所有下级共" + menu.DeleteAndAllChilds(menu2.ID).ToString() + "项", menu2.Serialize(), RoadFlow.Platform.Log.Types.菜单权限);
				string text = (menu2.ParentID == Guid.Empty) ? menu2.ID.ToString() : menu2.ParentID.ToString();
				base.ViewBag.Script = "parent.frames[0].reLoad('" + text + "');window.location='Body?id=" + text + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "';";
				menu.ClearAllDataTableCache();
			}
			if (menu2 != null && menu2.AppLibraryID.HasValue)
			{
				RoadFlow.Data.Model.AppLibrary appLibrary2 = new RoadFlow.Platform.AppLibrary().Get(menu2.AppLibraryID.Value);
				if (appLibrary2 != null)
				{
					value = appLibrary2.Type.ToString();
				}
			}
			base.ViewBag.AppTypesOptions = appLibrary.GetTypeOptions(value);
			base.ViewBag.AppID = menu2.AppLibraryID.ToString();
			return View(menu2);
		}

		[MyAttribute(CheckApp = false)]
		public string GetApps()
		{
			string str = base.Request.Form["type"];
			string value = base.Request.Form["value"];
			return new RoadFlow.Platform.AppLibrary().GetAppsOptions(str.ToGuid(), value);
		}

		public ActionResult AddApp()
		{
			return AddApp(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddApp(FormCollection collection)
		{
			RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
			RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
			string text = base.Request.QueryString["id"];
			if (collection != null)
			{
				menu.Get(text.ToGuid());
				if (!base.Request.Form["Save"].IsNullOrEmpty())
				{
					string text2 = base.Request.Form["Name"];
					string text6 = base.Request.Form["Type"];
					string str = base.Request.Form["AppID"];
					string text3 = base.Request.Form["Params"];
					string text4 = base.Request.Form["Ico"];
					string text5 = base.Request.Form["IcoColor"];
					RoadFlow.Data.Model.Menu menu2 = new RoadFlow.Data.Model.Menu();
					menu2.ID = Guid.NewGuid();
					menu2.ParentID = text.ToGuid();
					menu2.Title = text2.Trim();
					menu2.Sort = menu.GetMaxSort(menu2.ParentID);
					if (str.IsGuid())
					{
						menu2.AppLibraryID = str.ToGuid();
					}
					else
					{
						menu2.AppLibraryID = null;
					}
					menu2.Params = (text3.IsNullOrEmpty() ? null : text3.Trim());
					if (!text4.IsNullOrEmpty())
					{
						menu2.Ico = text4;
					}
					if (!text5.IsNullOrEmpty())
					{
						menu2.IcoColor = text5;
					}
					menu.Add(menu2);
					RoadFlow.Platform.Log.Add("添加了菜单", menu2.Serialize(), RoadFlow.Platform.Log.Types.菜单权限);
					string str2 = text;
					base.ViewBag.Script = "alert('添加成功');parent.frames[0].reLoad('" + str2 + "');";
					menu.ClearAllDataTableCache();
				}
			}
			base.ViewBag.AppTypesOptions = appLibrary.GetTypeOptions();
			return View();
		}

		public ActionResult Sort()
		{
			return Sort(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Sort(FormCollection collection)
		{
			RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
			List<RoadFlow.Data.Model.Menu> list = new List<RoadFlow.Data.Model.Menu>();
			string str = base.Request.QueryString["id"];
			RoadFlow.Data.Model.Menu menu2 = menu.Get(str.ToGuid());
			list = menu.GetChild(menu2.ParentID);
			if (collection != null)
			{
				string text = base.Request.Form["sortapp"];
				if (text.IsNullOrEmpty())
				{
					return View(list);
				}
				string[] array = text.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					Guid test;
					if (array[i].IsGuid(out test))
					{
						menu.UpdateSort(test, i + 1);
					}
				}
				string str2 = menu2.ParentID.ToString();
				base.ViewBag.Script = "parent.frames[0].reLoad('" + str2 + "');";
				list = menu.GetChild(menu2.ParentID);
				menu.ClearAllDataTableCache();
			}
			return View(list);
		}

		public ActionResult Menu()
		{
			return View();
		}

		public ActionResult Buttons()
		{
			string text = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"];
			base.ViewBag.Query = text;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string ButtonsQuery()
		{
			string title = base.Request.Form["Title"];
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			string order = (text.IsNullOrEmpty() ? "Type" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2);
			long count;
			List<RoadFlow.Data.Model.AppLibraryButtons> pagerData = new RoadFlow.Platform.AppLibraryButtons().GetPagerData(out count, pageSize, pageNumber, title, order);
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.AppLibraryButtons item in pagerData)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Name"] = item.Name;
				jsonData2["Ico"] = (item.Ico.IsNullOrEmpty() ? "" : (item.Ico.IsFontIco() ? ("<i class='fa " + item.Ico + "' style='font-size:14px;vertical-align:middle;margin-right:3px;'></i>") : ("<img src=\"" + base.Url.Content("~" + item.Ico) + "\" style=\"vertical-align:middle;\" />")));
				jsonData2["Events"] = item.Events;
				jsonData2["Note"] = item.Note;
				jsonData2["Sort"] = item.Sort;
				jsonData2["Opation"] = "<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"add('" + item.ID + "');return false;\">编辑</a>";
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}

		public ActionResult ButtionsEdit()
		{
			return ButtionsEdit(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ButtionsEdit(FormCollection collection)
		{
			RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons = null;
			RoadFlow.Platform.AppLibraryButtons appLibraryButtons2 = new RoadFlow.Platform.AppLibraryButtons();
			string str = base.Request.QueryString["butid"];
			if (str.IsGuid())
			{
				appLibraryButtons = appLibraryButtons2.Get(str.ToGuid());
			}
			if (collection != null)
			{
				string str2 = base.Request.Form["Name"];
				string events = base.Request.Form["Events"];
				string ico = base.Request.Form["Ico"];
				string note = base.Request.Form["Note"];
				string str3 = base.Request.Form["Sort"];
				bool flag = false;
				string oldXML = string.Empty;
				if (appLibraryButtons == null)
				{
					flag = true;
					appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons();
					appLibraryButtons.ID = Guid.NewGuid();
				}
				else
				{
					oldXML = appLibraryButtons.Serialize();
				}
				appLibraryButtons.Name = str2.Trim1();
				appLibraryButtons.Events = events;
				appLibraryButtons.Ico = ico;
				appLibraryButtons.Note = note;
				appLibraryButtons.Sort = str3.ToInt();
				if (flag)
				{
					appLibraryButtons2.Add(appLibraryButtons);
					RoadFlow.Platform.Log.Add("添加了按钮", appLibraryButtons.Serialize(), RoadFlow.Platform.Log.Types.系统管理);
				}
				else
				{
					appLibraryButtons2.Update(appLibraryButtons);
					RoadFlow.Platform.Log.Add("修改了按钮", appLibraryButtons.Serialize(), RoadFlow.Platform.Log.Types.系统管理, oldXML);
				}
				base.ViewBag.Script = "alert('保存成功!');new RoadUI.Window().getOpenerWindow().query();new RoadUI.Window().close();";
			}
			string text = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&title=";
			base.ViewBag.Query = text;
			if (appLibraryButtons == null)
			{
				appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons();
				appLibraryButtons.Sort = appLibraryButtons2.GetMaxSort();
			}
			return View(appLibraryButtons);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string ButtionsDelete()
		{
			RoadFlow.Platform.AppLibraryButtons appLibraryButtons = new RoadFlow.Platform.AppLibraryButtons();
			string[] array = (base.Request.Form["ids"] ?? "").Split(',');
			foreach (string str in array)
			{
				RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons2 = appLibraryButtons.Get(str.ToGuid());
				if (appLibraryButtons2 != null)
				{
					appLibraryButtons.Delete(appLibraryButtons2.ID);
					RoadFlow.Platform.Log.Add("删除了按钮", appLibraryButtons2.Serialize(), RoadFlow.Platform.Log.Types.系统管理);
				}
			}
			return "删除成功!";
		}

		public ActionResult Refresh()
		{
			return View();
		}

		public string Refresh1()
		{
			new RoadFlow.Platform.MenuUser().RefreshUsers();
			return "更新完成!";
		}
	}
}
