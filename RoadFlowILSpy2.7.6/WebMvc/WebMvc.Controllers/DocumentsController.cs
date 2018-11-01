using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class DocumentsController : MyController
	{
		public ActionResult Index()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Tree()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult ListNoRead()
		{
			string text = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&dirid=" + base.Request.QueryString["dirid"];
			base.ViewBag.Query = text;
			return View();
		}

		public ActionResult List()
		{
			string text = "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&dirid=" + base.Request.QueryString["dirid"];
			base.ViewBag.Query = text;
			return View();
		}

		public ActionResult DocAdd()
		{
			return DocAdd(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult DocAdd(FormCollection collection)
		{
			string str = base.Request.QueryString["docid"];
			RoadFlow.Platform.Documents documents = new RoadFlow.Platform.Documents();
			RoadFlow.Platform.DocumentDirectory documentDirectory = new RoadFlow.Platform.DocumentDirectory();
			RoadFlow.Platform.DocumentsReadUsers documentsReadUsers = new RoadFlow.Platform.DocumentsReadUsers();
			RoadFlow.Data.Model.Documents documents2 = null;
			if (str.IsGuid())
			{
				documents2 = documents.Get(str.ToGuid());
			}
			if (collection != null)
			{
				string str2 = base.Request.Form["DirectoryID"];
				string str3 = base.Request.Form["Title1"];
				string readUsers = base.Request.Form["ReadUsers"];
				string text = base.Request.Form["Source"];
				string contents = base.Request.Form["Contents"];
				string files = base.Request.Form["Files"];
				string oldXML = string.Empty;
				bool flag = false;
				if (documents2 == null)
				{
					flag = true;
					documents2 = new RoadFlow.Data.Model.Documents();
					documents2.ID = Guid.NewGuid();
					documents2.ReadCount = 0;
					documents2.WriteTime = DateTimeNew.Now;
					documents2.WriteUserID = RoadFlow.Platform.Users.CurrentUserID;
					documents2.WriteUserName = RoadFlow.Platform.Users.CurrentUserName;
				}
				else
				{
					oldXML = documents2.Serialize();
				}
				documents2.Contents = contents;
				documents2.DirectoryID = str2.ToGuid();
				documents2.DirectoryName = documentDirectory.GetName(documents2.DirectoryID);
				documents2.EditTime = DateTimeNew.Now;
				documents2.EditUserID = RoadFlow.Platform.Users.CurrentUserID;
				documents2.EditUserName = RoadFlow.Platform.Users.CurrentUserName;
				documents2.Files = files;
				documents2.ReadUsers = readUsers;
				documents2.Source = (text.IsNullOrEmpty() ? " " : text);
				documents2.Title = str3.Trim1();
				if (flag)
				{
					documents.Add(documents2);
					RoadFlow.Platform.Log.Add("添加了文档", documents2.Serialize(), RoadFlow.Platform.Log.Types.文档中心);
				}
				else
				{
					documents.Update(documents2);
					RoadFlow.Platform.Log.Add("修改了文档", documents2.Serialize(), RoadFlow.Platform.Log.Types.文档中心, oldXML, documents2.Serialize());
				}
				List<RoadFlow.Data.Model.Users> obj = documents2.ReadUsers.IsNullOrEmpty() ? documentDirectory.GetReadUsers(documents2.DirectoryID) : new RoadFlow.Platform.Organize().GetAllUsers(documents2.ReadUsers);
				documentsReadUsers.Delete(documents2.ID);
				bool isUse = RoadFlow.Platform.WeiXin.Config.IsUse;
				Message message = new Message();
				StringBuilder stringBuilder = new StringBuilder();
				foreach (RoadFlow.Data.Model.Users item in obj)
				{
					RoadFlow.Data.Model.DocumentsReadUsers documentsReadUsers2 = new RoadFlow.Data.Model.DocumentsReadUsers();
					documentsReadUsers2.DocumentID = documents2.ID;
					documentsReadUsers2.IsRead = 0;
					documentsReadUsers2.UserID = item.ID;
					documentsReadUsers.Add(documentsReadUsers2);
					if (isUse)
					{
						stringBuilder.Append(item.Account);
						stringBuilder.Append('|');
					}
				}
				string empty = string.Empty;
				empty = ((!flag) ? ("'DocRead" + base.Request.Url.Query + "'") : ("'List" + base.Request.Url.Query + "'"));
				if (isUse)
				{
					message.SendText(documents2.Title, stringBuilder.ToString().TrimEnd('|'), "", "", 0, new Agents().GetAgentIDByCode("weixinagents_documents"), true);
				}
				base.ViewBag.script = "alert('保存成功!');window.location=" + empty + ";";
			}
			if (documents2 == null)
			{
				documents2 = new RoadFlow.Data.Model.Documents();
			}
			return View(documents2);
		}

		public ActionResult DirAdd()
		{
			return DirAdd(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult DirAdd(FormCollection collection)
		{
			string str = base.Request.QueryString["DirID"];
			string str2 = base.Request.QueryString["currentDirID"];
			RoadFlow.Platform.DocumentDirectory documentDirectory = new RoadFlow.Platform.DocumentDirectory();
			RoadFlow.Data.Model.DocumentDirectory documentDirectory2 = null;
			if (str2.IsGuid())
			{
				documentDirectory2 = documentDirectory.Get(str2.ToGuid());
			}
			if (collection != null)
			{
				string str3 = base.Request.Form["Name"];
				string readUsers = base.Request.Form["ReadUsers"];
				string publishUsers = base.Request.Form["PublishUsers"];
				string manageUsers = base.Request.Form["ManageUsers"];
				string str4 = base.Request.Form["Sort"];
				bool flag = false;
				string oldXML = string.Empty;
				if (documentDirectory2 == null)
				{
					flag = true;
					documentDirectory2 = new RoadFlow.Data.Model.DocumentDirectory();
					documentDirectory2.ID = Guid.NewGuid();
					documentDirectory2.ParentID = str.ToGuid();
				}
				else
				{
					oldXML = documentDirectory2.Serialize();
				}
				documentDirectory2.ManageUsers = manageUsers;
				documentDirectory2.Name = str3.Trim1();
				documentDirectory2.PublishUsers = publishUsers;
				documentDirectory2.ReadUsers = readUsers;
				documentDirectory2.Sort = str4.ToInt();
				if (flag)
				{
					documentDirectory.Add(documentDirectory2);
					RoadFlow.Platform.Log.Add("添加了栏目", documentDirectory2.Serialize(), RoadFlow.Platform.Log.Types.文档中心);
				}
				else
				{
					documentDirectory.Update(documentDirectory2);
					RoadFlow.Platform.Log.Add("修改了栏目", documentDirectory2.Serialize(), RoadFlow.Platform.Log.Types.文档中心, oldXML, documentDirectory2.Serialize());
				}
				documentDirectory.ClearDirUsersCache(documentDirectory2.ID);
				documentDirectory.ClearCache();
				base.ViewBag.script = "parent.frames[0].reLoad('" + documentDirectory2.ParentID + "');alert('保存成功!');window.location='List" + base.Request.Url.Query + "';";
			}
			if (documentDirectory2 == null)
			{
				documentDirectory2 = new RoadFlow.Data.Model.DocumentDirectory();
				documentDirectory2.Sort = documentDirectory.GetMaxSort(str.ToGuid());
				documentDirectory2.ParentID = str.ToGuid();
			}
			return View(documentDirectory2);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult DirDelete(FormCollection collection)
		{
			string text = base.Request.QueryString["DirID"];
			string str = base.Request.QueryString["currentDirID"];
			RoadFlow.Platform.DocumentDirectory documentDirectory = new RoadFlow.Platform.DocumentDirectory();
			RoadFlow.Data.Model.DocumentDirectory documentDirectory2 = null;
			if (str.IsGuid())
			{
				documentDirectory2 = documentDirectory.Get(str.ToGuid());
			}
			if (documentDirectory2 == null)
			{
				base.ViewBag.script = "alert('栏目为空!');window.location='List" + base.Request.Url.Query + "';";
				return View();
			}
			if (documentDirectory2.ParentID == Guid.Empty)
			{
				base.ViewBag.script = "alert('根栏目不能删除根栏目!');window.location=window.location;";
				return View();
			}
			string allChildIdString = documentDirectory.GetAllChildIdString(documentDirectory2.ID);
			RoadFlow.Platform.Documents documents = new RoadFlow.Platform.Documents();
			string[] array = allChildIdString.Split(',');
			foreach (string str2 in array)
			{
				documentDirectory.Delete(str2.ToGuid());
				documents.DeleteByDirectoryID(str2.ToGuid());
				documentDirectory.ClearDirUsersCache(str2.ToGuid());
			}
			documentDirectory.ClearCache();
			RoadFlow.Platform.Log.Add("删除的文档栏目及其所有下级栏目", allChildIdString, RoadFlow.Platform.Log.Types.文档中心);
			base.ViewBag.script = "parent.frames[0].reLoad('" + documentDirectory2.ParentID + "');alert('删除成功!');window.location='List" + base.Request.Url.Query + "';";
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false)]
		public ActionResult DocRead()
		{
			RoadFlow.Data.Model.Documents documents = null;
			RoadFlow.Platform.Documents documents2 = new RoadFlow.Platform.Documents();
			RoadFlow.Platform.DocumentsReadUsers documentsReadUsers = new RoadFlow.Platform.DocumentsReadUsers();
			bool flag = false;
			string str = base.Request.QueryString["docid"];
			Guid currentUserID = RoadFlow.Platform.Users.CurrentUserID;
			if (str.IsGuid())
			{
				documents = documents2.Get(str.ToGuid());
				if (documents != null)
				{
					if (documentsReadUsers.Get(documents.ID, currentUserID) == null)
					{
						base.Response.Write("您无权查看该文档!");
						base.Response.End();
						return null;
					}
					flag = (new RoadFlow.Platform.DocumentDirectory().HasPublish(documents.DirectoryID, currentUserID) || new RoadFlow.Platform.DocumentDirectory().HasManage(documents.DirectoryID, currentUserID));
					documents2.UpdateReadCount(documents.ID);
					documentsReadUsers.UpdateRead(documents.ID, currentUserID);
				}
			}
			base.ViewBag.IsEdit = flag;
			if (documents == null)
			{
				documents = new RoadFlow.Data.Model.Documents();
			}
			return View(documents);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public string DocDelete()
		{
			RoadFlow.Data.Model.Documents documents = null;
			RoadFlow.Platform.Documents documents2 = new RoadFlow.Platform.Documents();
			string str = base.Request.QueryString["docid"];
			if (str.IsGuid())
			{
				documents = documents2.Get(str.ToGuid());
			}
			if (documents != null)
			{
				documents2.Delete(documents.ID);
				new RoadFlow.Platform.DocumentsReadUsers().Delete(documents.ID);
				RoadFlow.Platform.Log.Add("删除了文档", documents.Serialize(), RoadFlow.Platform.Log.Types.文档中心);
				return "1";
			}
			return "未找到文档";
		}

		[MyAttribute(CheckApp = false)]
		public string Tree1()
		{
			return new RoadFlow.Platform.DocumentDirectory().GetTreeJsonString();
		}

		[MyAttribute(CheckApp = false)]
		public string TreeRefresh()
		{
			string str = base.Request["refreshid"];
			if (str.IsGuid())
			{
				return new RoadFlow.Platform.DocumentDirectory().GetTreeRefreshJsonString(str.ToGuid());
			}
			return "[]";
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public string QueryNoRead()
		{
			string str = base.Request.Form["DirID"];
			string str2 = base.Request.Form["Title1"];
			string date = base.Request.Form["Date1"];
			string date2 = base.Request.Form["Date2"];
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			RoadFlow.Platform.Documents documents = new RoadFlow.Platform.Documents();
			new RoadFlow.Platform.DocumentDirectory();
			string dirID = "";
			if (str.IsGuid())
			{
				dirID = new RoadFlow.Platform.DocumentDirectory().GetAllChildIdString(str.ToGuid(), RoadFlow.Platform.Users.CurrentUserID);
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			DataTable obj = documents.GetList(order: (text.IsNullOrEmpty() ? "WriteTime" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2), count: out count, size: pageSize, number: pageNumber, dirID: dirID, userID: RoadFlow.Platform.Users.CurrentUserID.ToString(), title: str2.Trim1(), date1: date, date2: date2, isNoRead: true);
			JsonData jsonData = new JsonData();
			foreach (DataRow row in obj.Rows)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["Title"] = "<a class=\"blue\" href=\"javascript:;\" onclick='showDoc(\"" + row["ID"].ToString() + "\",\"{{window.encodeURIComponent(value.Title)}}\");return false;'>" + row["Title"].ToString() + "</a><span style=\"margin-left:5px;\"><img src=\"../Images/loading/new.png\" style=\"border:0 none; vertical-align:middle;\" /></span>";
				jsonData2["DirectoryName"] = row["DirectoryName"].ToString();
				jsonData2["WriteUserName"] = row["WriteUserName"].ToString();
				jsonData2["WriteTime"] = row["WriteTime"].ToString().ToDateTimeString();
				jsonData2["ReadCount"] = row["ReadCount"].ToString();
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public string Query()
		{
			string str = base.Request.Form["DirID"];
			string str2 = base.Request.Form["Title1"];
			string date = base.Request.Form["Date1"];
			string date2 = base.Request.Form["Date2"];
			string text = base.Request.Form["sidx"];
			string text2 = base.Request.Form["sord"];
			RoadFlow.Platform.Documents documents = new RoadFlow.Platform.Documents();
			new RoadFlow.Platform.DocumentDirectory();
			string dirID = "";
			if (str.IsGuid())
			{
				dirID = new RoadFlow.Platform.DocumentDirectory().GetAllChildIdString(str.ToGuid(), RoadFlow.Platform.Users.CurrentUserID);
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			DataTable obj = documents.GetList(order: (text.IsNullOrEmpty() ? "WriteTime" : text) + " " + (text2.IsNullOrEmpty() ? "asc" : text2), count: out count, size: pageSize, number: pageNumber, dirID: dirID, userID: RoadFlow.Platform.Users.CurrentUserID.ToString(), title: str2.Trim1(), date1: date, date2: date2);
			JsonData jsonData = new JsonData();
			foreach (DataRow row in obj.Rows)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["Title"] = "<a class=\"blue\" href=\"javascript:;\" onclick='showDoc(\"" + row["ID"].ToString() + "\",\"{{window.encodeURIComponent(value.Title)}}\");return false;'>" + row["Title"].ToString() + "</a><span style=\"margin-left:5px;\">" + (("0" == row["IsRead"].ToString()) ? "<img src=\"../Images/loading/new.png\" style=\"border:0 none; vertical-align:middle;\" />" : "") + "</span>";
				jsonData2["DirectoryName"] = row["DirectoryName"].ToString();
				jsonData2["WriteUserName"] = row["WriteUserName"].ToString();
				jsonData2["WriteTime"] = row["WriteTime"].ToString().ToDateTimeString();
				jsonData2["ReadCount"] = row["ReadCount"].ToString();
				jsonData.Add(jsonData2);
			}
			return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
		}
	}
}
