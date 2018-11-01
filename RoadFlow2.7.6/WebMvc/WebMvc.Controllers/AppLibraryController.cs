using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class AppLibraryController : MyController
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Tree()
		{
			return View();
		}

		public ActionResult List()
		{
			string text = base.Request.QueryString["appid"];
			string text2 = base.Request.QueryString["tabid"];
			string text3 = base.Request.QueryString["typeid"];
			string text4 = string.Format("&appid={0}&tabid={1}&typeid={2}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"], base.Request.QueryString["typeid"]);
			base.ViewBag.Query1 = text4;
			base.ViewBag.TypeID = text3;
			base.ViewBag.AppID = text;
			base.ViewBag.TabID = text2;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string Delete()
		{
			RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
			string text = base.Request.Form["ids"];
			StringBuilder stringBuilder = new StringBuilder();
			using (TransactionScope transactionScope = new TransactionScope())
			{
				string[] array = text.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					Guid test;
					if (array[i].IsGuid(out test))
					{
						RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary.Get(test);
						if (appLibrary2 != null)
						{
							stringBuilder.Append(appLibrary2.Serialize());
							appLibrary.Delete(test);
							new RoadFlow.Platform.AppLibraryButtons1().DeleteByAppID(test);
							new RoadFlow.Platform.AppLibrarySubPages().DeleteByAppID(test);
						}
					}
				}
				new RoadFlow.Platform.Menu().ClearAllDataTableCache();
				new RoadFlow.Platform.AppLibraryButtons1().ClearCache();
				new RoadFlow.Platform.AppLibrarySubPages().ClearCache();
				RoadFlow.Platform.Log.Add("删除了一批应用程序库", stringBuilder.ToString(), RoadFlow.Platform.Log.Types.菜单权限);
				transactionScope.Complete();
			}
			return "删除成功!";
		}

		public ActionResult Edit()
		{
			return Edit(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(FormCollection collection)
		{
			string str = base.Request.QueryString["id"];
			string value = base.Request.QueryString["typeid"];
			RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
			RoadFlow.Data.Model.AppLibrary appLibrary2 = null;
			if (str.IsGuid())
			{
				appLibrary2 = appLibrary.Get(str.ToGuid());
			}
			bool flag = !str.IsGuid();
			string oldXML = string.Empty;
			if (appLibrary2 == null)
			{
				appLibrary2 = new RoadFlow.Data.Model.AppLibrary();
				appLibrary2.ID = Guid.NewGuid();
				base.ViewBag.TypeOptions = new RoadFlow.Platform.AppLibrary().GetTypeOptions(value);
				base.ViewBag.OpenOptions = new RoadFlow.Platform.Dictionary().GetOptionsByCode("appopenmodel");
			}
			else
			{
				oldXML = appLibrary2.Serialize();
				base.ViewBag.TypeOptions = new RoadFlow.Platform.AppLibrary().GetTypeOptions(appLibrary2.Type.ToString());
				base.ViewBag.OpenOptions = new RoadFlow.Platform.Dictionary().GetOptionsByCode("appopenmodel", RoadFlow.Platform.Dictionary.OptionValueField.Value, appLibrary2.OpenMode.ToString());
			}
			if (collection != null)
			{
				string title = collection["title"];
				string text = collection["address"];
				string str2 = collection["openModel"];
				string str3 = collection["width"];
				string str4 = collection["height"];
				string @params = collection["Params"];
				string note = collection["Note"];
				string text2 = collection["Ico"];
				string text3 = collection["IcoColor"];
				value = collection["type"];
				appLibrary2.Address = text.Trim();
				appLibrary2.Height = str4.ToIntOrNull();
				appLibrary2.Note = note;
				appLibrary2.OpenMode = str2.ToInt();
				appLibrary2.Params = @params;
				appLibrary2.Title = title;
				appLibrary2.Type = value.ToGuid();
				appLibrary2.Width = str3.ToIntOrNull();
				if (!text2.IsNullOrEmpty())
				{
					appLibrary2.Ico = text2;
				}
				else
				{
					appLibrary2.Ico = null;
				}
				if (!text3.IsNullOrEmpty())
				{
					appLibrary2.Color = text3.Trim();
				}
				else
				{
					appLibrary2.Color = null;
				}
				string text4 = base.Request.QueryString["pagesize"];
				string text5 = base.Request.QueryString["pagenumber"];
				using (TransactionScope transactionScope = new TransactionScope())
				{
					if (flag)
					{
						appLibrary.Add(appLibrary2);
						RoadFlow.Platform.Log.Add("添加了应用程序库", appLibrary2.Serialize(), RoadFlow.Platform.Log.Types.菜单权限);
						base.ViewBag.Script = "alert('添加成功!');new RoadUI.Window().reloadOpener(undefined,undefined,\"query('" + text4 + "','" + text5 + "')\");new RoadUI.Window().close();";
					}
					else
					{
						appLibrary.Update(appLibrary2);
						RoadFlow.Platform.Log.Add("修改了应用程序库", "", RoadFlow.Platform.Log.Types.菜单权限, oldXML, appLibrary2.Serialize());
						base.ViewBag.Script = "alert('修改成功!');new RoadUI.Window().reloadOpener(undefined,undefined,\"query('" + text4 + "','" + text5 + "')\");new RoadUI.Window().close();";
					}
					RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons = new RoadFlow.Platform.AppLibraryButtons1();
					string obj = base.Request.Form["buttonindex"] ?? "";
					List<RoadFlow.Data.Model.AppLibraryButtons1> allByAppID = appLibraryButtons.GetAllByAppID(appLibrary2.ID);
					List<RoadFlow.Data.Model.AppLibraryButtons1> list = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
					string[] array = obj.Split(',');
					foreach (string index in array)
					{
						string str5 = base.Request.Form["button_" + index];
						string str6 = base.Request.Form["buttonname_" + index];
						string text6 = base.Request.Form["buttonevents_" + index];
						string ico = base.Request.Form["buttonico_" + index];
						string str7 = base.Request.Form["showtype_" + index];
						string str8 = base.Request.Form["buttonsort_" + index];
						if (!str6.IsNullOrEmpty() && !text6.IsNullOrEmpty())
						{
							RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons2 = allByAppID.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == index.ToGuid());
							bool flag2 = false;
							if (appLibraryButtons2 == null)
							{
								flag2 = true;
								appLibraryButtons2 = new RoadFlow.Data.Model.AppLibraryButtons1();
								appLibraryButtons2.ID = Guid.NewGuid();
							}
							else
							{
								list.Add(appLibraryButtons2);
							}
							appLibraryButtons2.AppLibraryID = appLibrary2.ID;
							if (str5.IsGuid())
							{
								appLibraryButtons2.ButtonID = str5.ToGuid();
							}
							appLibraryButtons2.Events = text6;
							appLibraryButtons2.Ico = ico;
							appLibraryButtons2.Name = str6.Trim1();
							appLibraryButtons2.Sort = str8.ToInt(0);
							appLibraryButtons2.ShowType = str7.ToInt(0);
							appLibraryButtons2.Type = 0;
							if (flag2)
							{
								appLibraryButtons.Add(appLibraryButtons2);
							}
							else
							{
								appLibraryButtons.Update(appLibraryButtons2);
							}
						}
					}
					foreach (RoadFlow.Data.Model.AppLibraryButtons1 item in allByAppID)
					{
						if (list.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == item.ID) == null)
						{
							appLibraryButtons.Delete(item.ID);
						}
					}
					transactionScope.Complete();
					appLibraryButtons.ClearCache();
				}
				new RoadFlow.Platform.Menu().ClearAllDataTableCache();
				new RoadFlow.Platform.WorkFlow().ClearStartFlowsCache();
				appLibrary.ClearCache();
			}
			return View(appLibrary2);
		}

		public ActionResult SubPages()
		{
			return View();
		}

		public ActionResult SubPageEdit()
		{
			return SubPageEdit(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubPageEdit(FormCollection collection)
		{
			RoadFlow.Platform.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Platform.AppLibrarySubPages();
			RoadFlow.Data.Model.AppLibrarySubPages appLibrarySubPages2 = null;
			string str = base.Request.QueryString["subid"];
			if (str.IsGuid())
			{
				appLibrarySubPages2 = appLibrarySubPages.Get(str.ToGuid());
			}
			if (collection != null)
			{
				string str2 = base.Request.Form["Title"];
				string str3 = base.Request.Form["Address"];
				bool flag = false;
				if (appLibrarySubPages2 == null)
				{
					appLibrarySubPages2 = new RoadFlow.Data.Model.AppLibrarySubPages();
					flag = true;
					appLibrarySubPages2.ID = Guid.NewGuid();
					appLibrarySubPages2.AppLibraryID = base.Request.QueryString["id"].ToGuid();
				}
				appLibrarySubPages2.Name = str2.Trim1();
				appLibrarySubPages2.Address = str3.Trim1();
				using (TransactionScope transactionScope = new TransactionScope())
				{
					if (flag)
					{
						appLibrarySubPages.Add(appLibrarySubPages2);
						RoadFlow.Platform.Log.Add("添加了子页面", appLibrarySubPages2.Serialize(), RoadFlow.Platform.Log.Types.菜单权限);
						base.ViewBag.Script = "alert('添加成功!');window.location='SubPages" + base.Request.Url.Query + "';";
					}
					else
					{
						appLibrarySubPages.Update(appLibrarySubPages2);
						RoadFlow.Platform.Log.Add("修改了子页面", appLibrarySubPages2.Serialize(), RoadFlow.Platform.Log.Types.菜单权限);
						base.ViewBag.Script = "alert('保存成功!');window.location='SubPages" + base.Request.Url.Query + "';";
					}
					RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons = new RoadFlow.Platform.AppLibraryButtons1();
					string obj = base.Request.Form["buttonindex"] ?? "";
					List<RoadFlow.Data.Model.AppLibraryButtons1> allByAppID = appLibraryButtons.GetAllByAppID(appLibrarySubPages2.ID);
					List<RoadFlow.Data.Model.AppLibraryButtons1> list = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
					string[] array = obj.Split(',');
					foreach (string index in array)
					{
						string str4 = base.Request.Form["button_" + index];
						string str5 = base.Request.Form["buttonname_" + index];
						string text = base.Request.Form["buttonevents_" + index];
						string ico = base.Request.Form["buttonico_" + index];
						string str6 = base.Request.Form["showtype_" + index];
						string str7 = base.Request.Form["buttonsort_" + index];
						if (!str5.IsNullOrEmpty() && !text.IsNullOrEmpty())
						{
							RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons2 = allByAppID.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == index.ToGuid());
							bool flag2 = false;
							if (appLibraryButtons2 == null)
							{
								flag2 = true;
								appLibraryButtons2 = new RoadFlow.Data.Model.AppLibraryButtons1();
								appLibraryButtons2.ID = Guid.NewGuid();
							}
							else
							{
								list.Add(appLibraryButtons2);
							}
							appLibraryButtons2.AppLibraryID = appLibrarySubPages2.ID;
							if (str4.IsGuid())
							{
								appLibraryButtons2.ButtonID = str4.ToGuid();
							}
							appLibraryButtons2.Events = text;
							appLibraryButtons2.Ico = ico;
							appLibraryButtons2.Name = str5.Trim1();
							appLibraryButtons2.Sort = str7.ToInt(0);
							appLibraryButtons2.ShowType = str6.ToInt(0);
							appLibraryButtons2.Type = 0;
							if (flag2)
							{
								appLibraryButtons.Add(appLibraryButtons2);
							}
							else
							{
								appLibraryButtons.Update(appLibraryButtons2);
							}
						}
					}
					foreach (RoadFlow.Data.Model.AppLibraryButtons1 item in allByAppID)
					{
						if (list.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == item.ID) == null)
						{
							appLibraryButtons.Delete(item.ID);
						}
					}
					transactionScope.Complete();
					appLibraryButtons.ClearCache();
					appLibrarySubPages.ClearCache();
				}
			}
			if (appLibrarySubPages2 == null)
			{
				appLibrarySubPages2 = new RoadFlow.Data.Model.AppLibrarySubPages();
				appLibrarySubPages2.ID = Guid.Empty;
				appLibrarySubPages2.AppLibraryID = base.Request.QueryString["id"].ToGuid();
			}
			return View(appLibrarySubPages2);
		}

		public RedirectResult SubPageDelete()
		{
			string text = base.Request.Form["subpagesbox"] ?? "";
			RoadFlow.Platform.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Platform.AppLibrarySubPages();
			RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons = new RoadFlow.Platform.AppLibraryButtons1();
			using (TransactionScope transactionScope = new TransactionScope())
			{
				string[] array = text.Split(',');
				foreach (string str in array)
				{
					if (str.IsGuid())
					{
						appLibrarySubPages.Delete(str.ToGuid());
						appLibraryButtons.DeleteByAppID(str.ToGuid());
					}
				}
				RoadFlow.Platform.Log.Add("删除了子页面", text, RoadFlow.Platform.Log.Types.菜单权限);
				transactionScope.Complete();
			}
			appLibrarySubPages.ClearCache();
			appLibraryButtons.ClearCache();
			return Redirect("SubPages" + base.Request.Url.Query);
		}

		[MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
		public string GetApps()
		{
			string str = base.Request.Form["type"];
			string value = base.Request.Form["value"];
			return new RoadFlow.Platform.AppLibrary().GetAppsOptions(str.ToGuid(), value);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public string Query()
		{
			string str = base.Request.Form["Title"];
			string str2 = base.Request.Form["Address"];
			string str3 = base.Request.Form["typeid"];
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
			string type = str3.IsGuid() ? appLibrary.GetAllChildsIDString(str3.ToGuid()) : "";
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			string order = (text.IsNullOrEmpty() ? "Title" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2);
			long count;
			List<RoadFlow.Data.Model.AppLibrary> pagerData = appLibrary.GetPagerData(out count, pageSize, pageNumber, str.Trim1(), type, str2.Trim1(), order);
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.AppLibrary item in pagerData)
			{
				string empty = string.Empty;
				empty = ((!item.Ico.IsFontIco()) ? ("<img src=\"" + item.Ico.Trim1() + "\" style=\"vertical-align:middle;\" />") : ("<i class=\"fa " + item.Ico.Trim1() + "\" style=\"font-size:14px;vertical-align:middle;" + (item.Color.IsNullOrEmpty() ? "" : ("color:" + item.Color + ";")) + "\"></i>"));
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["Title"] = empty + "<span style=\"vertical-align:middle;margin-left:4px;\">" + item.Title + "</span>";
				jsonData2["Address"] = item.Address;
				jsonData2["TypeTitle"] = dictionary.GetTitle(item.Type);
				jsonData2["Opation"] = "<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"edit('" + item.ID.ToString() + "');return false;\" style=\"margin-right:6px;\">编辑</a><a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"editsubpage('" + item.ID.ToString() + "');return false;\">子页面</a>";
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}
	}
}
