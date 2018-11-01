using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Controllers
{
	public class MembersController : MyController
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

		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public string Tree1()
		{
			string msg;
			if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			string text = base.Request.QueryString["rootid"] ?? "";
			string b = base.Request.QueryString["showtype"] ?? "";
			string searchword = base.Request.QueryString["searchword"] ?? "";
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			RoadFlow.Platform.WorkGroup workGroup = new RoadFlow.Platform.WorkGroup();
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			StringBuilder stringBuilder = new StringBuilder("[", 1000);
			if (!searchword.IsNullOrEmpty())
			{
				if ("1" == b)
				{
					List<RoadFlow.Data.Model.WorkGroup> list = workGroup.GetAll().FindAll((RoadFlow.Data.Model.WorkGroup p) => p.Name.Contains(searchword, StringComparison.CurrentCultureIgnoreCase));
					stringBuilder.Append("{");
					stringBuilder.AppendFormat("\"id\":\"{0}\",", Guid.Empty);
					stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
					stringBuilder.AppendFormat("\"title\":\"查询“{0}”的结果\",", searchword);
					stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/search.png"));
					stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
					stringBuilder.AppendFormat("\"type\":\"{0}\",", 1);
					stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", list.Count);
					stringBuilder.Append("\"childs\":[");
					int count = list.Count;
					int num = 0;
					foreach (RoadFlow.Data.Model.WorkGroup item in list)
					{
						stringBuilder.Append("{");
						stringBuilder.AppendFormat("\"id\":\"{0}\",", item.ID);
						stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
						stringBuilder.AppendFormat("\"title\":\"{0}\",", item.Name);
						stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"type\":\"{0}\",", 5);
						stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", 0);
						stringBuilder.Append("\"childs\":[");
						stringBuilder.Append("]");
						stringBuilder.Append("}");
						if (num++ < count - 1)
						{
							stringBuilder.Append(",");
						}
					}
				}
				else
				{
					List<RoadFlow.Data.Model.Organize> list2 = organize.GetAll().FindAll((RoadFlow.Data.Model.Organize p) => p.Name.Contains(searchword, StringComparison.CurrentCultureIgnoreCase));
					List<RoadFlow.Data.Model.Users> list3 = users.GetAll().FindAll((RoadFlow.Data.Model.Users p) => p.Name.Contains(searchword, StringComparison.CurrentCultureIgnoreCase));
					stringBuilder.Append("{");
					stringBuilder.AppendFormat("\"id\":\"{0}\",", Guid.Empty);
					stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
					stringBuilder.AppendFormat("\"title\":\"查询“{0}”的结果\",", searchword);
					stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/search.png"));
					stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
					stringBuilder.AppendFormat("\"type\":\"{0}\",", 1);
					stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", list2.Count + list3.Count);
					stringBuilder.Append("\"childs\":[");
					foreach (RoadFlow.Data.Model.Organize item2 in list2)
					{
						stringBuilder.Append("{");
						stringBuilder.AppendFormat("\"id\":\"{0}\",", item2.ID);
						stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
						stringBuilder.AppendFormat("\"title\":\"{0}\",", item2.Name);
						stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"type\":\"{0}\",", item2.Type);
						stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", item2.ChildsLength);
						stringBuilder.Append("\"childs\":[");
						stringBuilder.Append("]");
						stringBuilder.Append("}");
						if (item2.ID != list2.Last().ID || list3.Count > 0)
						{
							stringBuilder.Append(",");
						}
					}
					foreach (RoadFlow.Data.Model.Users item3 in list3)
					{
						stringBuilder.Append("{");
						stringBuilder.AppendFormat("\"id\":\"{0}\",", item3.ID);
						stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
						stringBuilder.AppendFormat("\"title\":\"{0}\",", item3.Name);
						stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/contact_grey.png"));
						stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"type\":\"{0}\",", "4");
						stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", "0");
						stringBuilder.Append("\"childs\":[");
						stringBuilder.Append("]");
						stringBuilder.Append("}");
						if (item3.ID != list3.Last().ID)
						{
							stringBuilder.Append(",");
						}
					}
				}
				stringBuilder.Append("]}]");
				return stringBuilder.ToString();
			}
			if ("1" == b)
			{
				List<RoadFlow.Data.Model.WorkGroup> all = workGroup.GetAll();
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", Guid.Empty);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
				stringBuilder.AppendFormat("\"title\":\"{0}\",", "角色组");
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/group.gif"));
				stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"type\":\"{0}\",", 5);
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", all.Count);
				stringBuilder.Append("\"childs\":[");
				int count2 = all.Count;
				int num3 = 0;
				foreach (RoadFlow.Data.Model.WorkGroup item4 in all)
				{
					List<RoadFlow.Data.Model.Users> allUsers = organize.GetAllUsers("w_" + item4.ID.ToString());
					stringBuilder.Append("{");
					stringBuilder.AppendFormat("\"id\":\"{0}\",", item4.ID);
					stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
					stringBuilder.AppendFormat("\"title\":\"{0}\",", item4.Name);
					stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
					stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
					stringBuilder.AppendFormat("\"type\":\"{0}\",", 5);
					stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", allUsers.Count);
					stringBuilder.Append("\"childs\":[");
					stringBuilder.Append("]");
					stringBuilder.Append("}");
					if (num3++ < count2 - 1)
					{
						stringBuilder.Append(",");
					}
				}
				stringBuilder.Append("]");
				stringBuilder.Append("}");
				stringBuilder.Append("]");
				base.Response.Write(stringBuilder.ToString());
				base.Response.End();
				return "";
			}
			if (text.IsNullOrEmpty())
			{
				text = organize.GetRoot().ID.ToString();
			}
			string[] array = text.Split(new string[1]
			{
				","
			}, StringSplitOptions.RemoveEmptyEntries);
			int num5 = 0;
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				List<RoadFlow.Data.Model.Users> list4 = new List<RoadFlow.Data.Model.Users>();
				Guid test = Guid.Empty;
				if (text2.IsGuid(out test))
				{
					RoadFlow.Data.Model.Organize organize2 = organize.Get(test);
					if (organize2 != null)
					{
						list4 = users.GetAllByOrganizeID(test);
						stringBuilder.Append("{");
						stringBuilder.AppendFormat("\"id\":\"{0}\",", organize2.ID);
						stringBuilder.AppendFormat("\"parentID\":\"{0}\",", organize2.ParentID);
						stringBuilder.AppendFormat("\"title\":\"{0}\",", organize2.Name);
						stringBuilder.AppendFormat("\"ico\":\"{0}\",", (array.Length == 1) ? base.Url.Content("~/images/ico/icon_site.gif") : "");
						stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"type\":\"{0}\",", organize2.Type);
						stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (organize2.ChildsLength == 0 && list4.Count == 0) ? "0" : "1");
						stringBuilder.Append("\"childs\":[");
					}
				}
				else if (text2.StartsWith("u_"))
				{
					RoadFlow.Data.Model.Users users2 = users.Get(users.RemovePrefix1(text2).ToGuid());
					if (users2 != null)
					{
						stringBuilder.Append("{");
						stringBuilder.AppendFormat("\"id\":\"{0}\",", users2.ID);
						stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
						stringBuilder.AppendFormat("\"title\":\"{0}\",", users2.Name);
						stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/contact_grey.png"));
						stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"type\":\"{0}\",", "4");
						stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", "0");
						stringBuilder.Append("\"childs\":[");
					}
				}
				else if (text2.StartsWith("w_"))
				{
					RoadFlow.Data.Model.WorkGroup workGroup2 = workGroup.Get(workGroup.RemovePrefix1(text2).ToGuid());
					if (workGroup2 != null)
					{
						list4 = organize.GetAllUsers(text2);
						stringBuilder.Append("{");
						stringBuilder.AppendFormat("\"id\":\"{0}\",", workGroup2.ID);
						stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty);
						stringBuilder.AppendFormat("\"title\":\"{0}\",", workGroup2.Name);
						stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"type\":\"{0}\",", "5");
						stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (list4.Count > 0) ? "1" : "0");
						stringBuilder.Append("\"childs\":[");
					}
				}
				if (array.Length == 1)
				{
					List<RoadFlow.Data.Model.Organize> obj = text2.IsGuid() ? organize.GetChilds(test) : new List<RoadFlow.Data.Model.Organize>();
					int count3 = obj.Count;
					int num6 = 0;
					foreach (RoadFlow.Data.Model.Organize item5 in obj)
					{
						stringBuilder.Append("{");
						stringBuilder.AppendFormat("\"id\":\"{0}\",", item5.ID);
						stringBuilder.AppendFormat("\"parentID\":\"{0}\",", item5.ParentID);
						stringBuilder.AppendFormat("\"title\":\"{0}\",", item5.Name);
						stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
						stringBuilder.AppendFormat("\"type\":\"{0}\",", item5.Type);
						stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", item5.ChildsLength);
						stringBuilder.Append("\"childs\":[");
						stringBuilder.Append("]");
						stringBuilder.Append("}");
						if (num6++ < count3 - 1 || list4.Count > 0)
						{
							stringBuilder.Append(",");
						}
					}
					if (list4.Count > 0)
					{
						List<RoadFlow.Data.Model.UsersRelation> allByOrganizeID = new RoadFlow.Platform.UsersRelation().GetAllByOrganizeID(test);
						int count4 = list4.Count;
						int num8 = 0;
						foreach (RoadFlow.Data.Model.Users item6 in list4)
						{
							RoadFlow.Data.Model.UsersRelation usersRelation = allByOrganizeID.Find((RoadFlow.Data.Model.UsersRelation p) => p.UserID == item6.ID);
							stringBuilder.Append("{");
							stringBuilder.AppendFormat("\"id\":\"{0}\",", item6.ID);
							stringBuilder.AppendFormat("\"parentID\":\"{0}\",", test);
							stringBuilder.AppendFormat("\"title\":\"{0}{1}\",", item6.Name, (usersRelation != null && usersRelation.IsMain == 0) ? "<span style='color:#999;'>[兼任]</span>" : "");
							stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/contact_grey.png"));
							stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
							stringBuilder.AppendFormat("\"type\":\"{0}\",", "4");
							stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", "0");
							stringBuilder.Append("\"childs\":[");
							stringBuilder.Append("]");
							stringBuilder.Append("}");
							if (num8++ < count4 - 1)
							{
								stringBuilder.Append(",");
							}
						}
					}
				}
				stringBuilder.Append("]");
				stringBuilder.Append("}");
				if (num5++ < array.Length - 1)
				{
					stringBuilder.Append(",");
				}
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public string TreeRefresh()
		{
			string msg;
			if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			string text = base.Request.QueryString["refreshid"] ?? "";
			string b = base.Request.QueryString["showtype"] ?? "";
			string b2 = base.Request.QueryString["type"] ?? "";
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			StringBuilder stringBuilder = new StringBuilder("[", 1000);
			if ("1" == b)
			{
				List<RoadFlow.Data.Model.Users> allUsers = organize.GetAllUsers("w_" + text);
				foreach (RoadFlow.Data.Model.Users item in allUsers)
				{
					stringBuilder.Append("{");
					stringBuilder.AppendFormat("\"id\":\"{0}\",", item.ID);
					stringBuilder.AppendFormat("\"parentID\":\"w_{0}\",", text);
					stringBuilder.AppendFormat("\"title\":\"{0}\",", item.Name);
					stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/contact_grey.png"));
					stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
					stringBuilder.AppendFormat("\"type\":\"{0}\",", "4");
					stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", "0");
					stringBuilder.Append("\"childs\":[");
					stringBuilder.Append("]");
					stringBuilder.Append("}");
					if (item.ID != allUsers.Last().ID)
					{
						stringBuilder.Append(",");
					}
				}
				stringBuilder.Append("]");
				base.Response.Write(stringBuilder.ToString());
				base.Response.End();
				return "";
			}
			Guid test;
			if (!text.IsGuid(out test))
			{
				stringBuilder.Append("]");
				return stringBuilder.ToString();
			}
			List<RoadFlow.Data.Model.Organize> childs = organize.GetChilds(test);
			int count = childs.Count;
			int num = 0;
			foreach (RoadFlow.Data.Model.Organize item2 in childs)
			{
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", item2.ID);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", text);
				stringBuilder.AppendFormat("\"title\":\"{0}\",", item2.Name);
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"type\":\"{0}\",", item2.Type);
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", item2.ChildsLength);
				stringBuilder.Append("\"childs\":[");
				stringBuilder.Append("]");
				stringBuilder.Append("}");
				if (num++ < count - 1)
				{
					stringBuilder.Append(",");
				}
			}
			List<RoadFlow.Data.Model.UsersRelation> allByOrganizeID = new RoadFlow.Platform.UsersRelation().GetAllByOrganizeID(test);
			List<RoadFlow.Data.Model.Users> obj = ("5" == b2) ? organize.GetAllUsers("w_" + text) : new RoadFlow.Platform.Users().GetAllByOrganizeID(test);
			int count2 = obj.Count;
			if (count2 > 0 && count > 0)
			{
				stringBuilder.Append(",");
			}
			int num3 = 0;
			foreach (RoadFlow.Data.Model.Users item3 in obj)
			{
				RoadFlow.Data.Model.UsersRelation usersRelation = allByOrganizeID.Find((RoadFlow.Data.Model.UsersRelation p) => p.UserID == item3.ID);
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", item3.ID);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", text);
				stringBuilder.AppendFormat("\"title\":\"{0}{1}\",", item3.Name, (usersRelation != null && usersRelation.IsMain == 0) ? "<span style='color:#999;'>[兼任]</span>" : "");
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/contact_grey.png"));
				stringBuilder.AppendFormat("\"link\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"type\":\"{0}\",", "4");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", "0");
				stringBuilder.Append("\"childs\":[");
				stringBuilder.Append("]");
				stringBuilder.Append("}");
				if (num3++ < count2 - 1)
				{
					stringBuilder.Append(",");
				}
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		public ActionResult Empty()
		{
			return View();
		}

		public ActionResult Body()
		{
			return Body(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Body(FormCollection collection)
		{
			RoadFlow.Data.Model.Organize organize = null;
			RoadFlow.Platform.Organize organize2 = new RoadFlow.Platform.Organize();
			string str = base.Request.QueryString["id"];
			if (str.IsGuid())
			{
				organize = organize2.Get(str.ToGuid());
			}
			if (!base.Request.Form["Save"].IsNullOrEmpty() && organize != null)
			{
				string text = base.Request.Form["Name"];
				string str2 = base.Request.Form["Type"];
				string str3 = base.Request.Form["Status"];
				string chargeLeader = base.Request.Form["ChargeLeader"];
				string leader = base.Request.Form["Leader"];
				string text2 = base.Request.Form["note"];
				string oldXML = organize.Serialize();
				organize.Name = text.Trim();
				organize.Type = str2.ToInt(1);
				organize.Status = str3.ToInt(0);
				organize.ChargeLeader = chargeLeader;
				organize.Leader = leader;
				organize.Note = (text2.IsNullOrEmpty() ? null : text2.Trim());
				organize2.Update(organize);
				if (RoadFlow.Platform.WeiXin.Config.IsUse)
				{
					new RoadFlow.Platform.WeiXin.Organize().EditDeptAsync(organize);
				}
				new RoadFlow.Platform.MenuUser().ClearCache();
				RoadFlow.Platform.Log.Add("修改了组织机构", "", RoadFlow.Platform.Log.Types.组织机构, oldXML, organize.Serialize());
				string str4 = (organize.ParentID == Guid.Empty) ? organize.ID.ToString() : organize.ParentID.ToString();
				base.ViewBag.Script = "alert('保存成功!');parent.frames[0].reLoad('" + str4 + "');";
			}
			if (!base.Request.Form["Move1"].IsNullOrEmpty() && organize != null)
			{
				string text3 = base.Request.Form["deptmove"];
				Guid test;
				if (text3.IsGuid(out test) && organize2.Move(organize.ID, test))
				{
					new RoadFlow.Platform.MenuUser().ClearCache();
					new RoadFlow.Platform.HomeItems().ClearCache();
					RoadFlow.Platform.Log.Add("移动了组织机构", "将机构：" + organize.ID + "移动到了：" + test, RoadFlow.Platform.Log.Types.组织机构);
					string text4 = (organize.ParentID == Guid.Empty) ? organize.ID.ToString() : organize.ParentID.ToString();
					base.ViewBag.Script = "alert('移动成功!');parent.frames[0].reLoad('" + text4 + "');parent.frames[0].reLoad('" + text3 + "')";
				}
				else
				{
					base.ViewBag.Script = "alert('移动失败!');";
				}
			}
			if (!base.Request.Form["Delete"].IsNullOrEmpty())
			{
				int num = organize2.DeleteAndAllChilds(organize.ID);
				new RoadFlow.Platform.MenuUser().ClearCache();
				new RoadFlow.Platform.HomeItems().ClearCache();
				RoadFlow.Platform.Log.Add("删除了组织机构及其所有下级共" + num.ToString() + "项", organize.Serialize(), RoadFlow.Platform.Log.Types.组织机构);
				string text5 = (organize.ParentID == Guid.Empty) ? organize.ID.ToString() : organize.ParentID.ToString();
				base.ViewBag.Script = "alert('共删除了" + num.ToString() + "项!');parent.frames[0].reLoad('" + text5 + "');";
			}
			if (!base.Request.Form["ToWeiXin"].IsNullOrEmpty())
			{
				RoadFlow.Platform.WeiXin.Organize organize3 = new RoadFlow.Platform.WeiXin.Organize();
				organize3.UpdateAllOrganize();
				organize3.UpdateAllUsers();
				base.ViewBag.script = "alert('同步完成!');window.location=window.location;";
			}
			if (organize == null)
			{
				organize = new RoadFlow.Data.Model.Organize();
			}
			base.ViewBag.TypeRadios = organize2.GetTypeRadio("Type", organize.Type.ToString(), "validate=\"radio\"");
			base.ViewBag.StatusRadios = organize2.GetStatusRadio("Status", organize.Status.ToString(), "validate=\"radio\"");
			return View(organize);
		}

		public ActionResult BodyAdd()
		{
			return BodyAdd(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult BodyAdd(FormCollection collection)
		{
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			RoadFlow.Data.Model.Organize organize2 = null;
			string text = base.Request.QueryString["id"];
			string empty = string.Empty;
			string text2 = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			Guid test;
			if (text.IsGuid(out test))
			{
				organize2 = organize.Get(test);
			}
			if (collection != null && organize2 != null)
			{
				empty = base.Request.Form["Name"];
				text2 = base.Request.Form["Type"];
				empty2 = base.Request.Form["Status"];
				empty3 = base.Request.Form["note"];
				RoadFlow.Data.Model.Organize organize3 = new RoadFlow.Data.Model.Organize();
				Guid guid2 = organize3.ID = Guid.NewGuid();
				organize3.Name = empty.Trim();
				organize3.Note = (empty3.IsNullOrEmpty() ? null : empty3.Trim());
				organize3.Number = organize2.Number + "," + guid2.ToString().ToLower();
				organize3.ParentID = organize2.ID;
				organize3.Sort = organize.GetMaxSort(organize2.ID);
				organize3.Status = (empty2.IsInt() ? empty2.ToInt() : 0);
				organize3.Type = text2.ToInt();
				organize3.Depth = organize2.Depth + 1;
				organize3.IntID = guid2.ToInt32();
				using (TransactionScope transactionScope = new TransactionScope())
				{
					organize.Add(organize3);
					organize.UpdateChildsLength(organize2.ID);
					transactionScope.Complete();
				}
				if (RoadFlow.Platform.WeiXin.Config.IsUse)
				{
					new RoadFlow.Platform.WeiXin.Organize().AddDeptAsync(organize3);
				}
				new RoadFlow.Platform.MenuUser().ClearCache();
				RoadFlow.Platform.Log.Add("添加了组织机构", organize3.Serialize(), RoadFlow.Platform.Log.Types.组织机构);
				base.ViewBag.Script = "alert('添加成功!');parent.frames[0].reLoad('" + text + "');window.location=window.location;";
			}
			base.ViewBag.TypeRadios = organize.GetTypeRadio("Type", text2, "validate=\"radio\"");
			base.ViewBag.StatusRadios = organize.GetStatusRadio("Status", "0", "validate=\"radio\"");
			return View();
		}

		public ActionResult UserAdd()
		{
			return UserAdd(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult UserAdd(FormCollection collection)
		{
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			string text = base.Request.QueryString["id"];
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			Guid test;
			if (collection != null && text.IsGuid(out test))
			{
				empty = base.Request.Form["Name"];
				empty2 = base.Request.Form["Account"];
				empty3 = base.Request.Form["Status"];
				empty4 = base.Request.Form["Note"];
				string str = base.Request.Form["Tel"];
				string str2 = base.Request.Form["Mobile"];
				string str3 = base.Request.Form["WeiXin"];
				string str4 = base.Request.Form["Email"];
				string str5 = base.Request.Form["Fax"];
				string str6 = base.Request.Form["QQ"];
				string str7 = base.Request.Form["OtherTel"];
				empty5 = base.Request.Form["Sex"];
				Guid guid = Guid.NewGuid();
				string contents = string.Empty;
				using (TransactionScope transactionScope = new TransactionScope())
				{
					RoadFlow.Data.Model.Users users2 = new RoadFlow.Data.Model.Users();
					users2.Account = empty2.Trim();
					users2.Name = empty.Trim();
					users2.Note = (empty4.IsNullOrEmpty() ? null : empty4);
					users2.Password = users.GetUserEncryptionPassword(guid.ToString(), users.GetInitPassword());
					users2.Sort = 1;
					users2.Status = (empty3.IsInt() ? empty3.ToInt() : 0);
					users2.ID = guid;
					users2.Tel = str.Trim1();
					users2.Mobile = str2.Trim1();
					users2.WeiXin = str3.Trim1();
					users2.WeiXin = str3.Trim1();
					users2.Email = str4.Trim1();
					users2.Fax = str5.Trim1();
					users2.QQ = str6.Trim1();
					users2.OtherTel = str7.Trim1();
					if (empty5.IsInt())
					{
						users2.Sex = empty5.ToInt();
					}
					users.Add(users2);
					RoadFlow.Data.Model.UsersRelation usersRelation = new RoadFlow.Data.Model.UsersRelation();
					usersRelation.IsMain = 1;
					usersRelation.OrganizeID = test;
					usersRelation.Sort = new RoadFlow.Platform.UsersRelation().GetMaxSort(test);
					usersRelation.UserID = guid;
					new RoadFlow.Platform.UsersRelation().Add(usersRelation);
					organize.UpdateChildsLength(test);
					if (RoadFlow.Platform.WeiXin.Config.IsUse)
					{
						new RoadFlow.Platform.WeiXin.Organize().AddUserAsync(users2);
					}
					contents = users2.Serialize();
					transactionScope.Complete();
				}
				new RoadFlow.Platform.MenuUser().ClearCache();
				new RoadFlow.Platform.HomeItems().ClearCache();
				new RoadFlow.Platform.DocumentDirectory().ClearAllDirUsersCache();
				RoadFlow.Platform.Log.Add("添加了人员", contents, RoadFlow.Platform.Log.Types.组织机构);
				base.ViewBag.Script = "alert('添加成功!');parent.frames[0].reLoad('" + text + "');window.location=window.location;";
			}
			base.ViewBag.StatusRadios = organize.GetStatusRadio("Status", "0", "validate=\"radio\"");
			base.ViewBag.SexRadios = organize.GetSexRadio("Sex", "", "validate=\"radio\"");
			return View();
		}

		public new ActionResult User()
		{
			return User(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public new ActionResult User(FormCollection collection)
		{
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			RoadFlow.Platform.UsersRelation usersRelation = new RoadFlow.Platform.UsersRelation();
			RoadFlow.Data.Model.Users users2 = null;
			RoadFlow.Data.Model.Organize organize2 = null;
			string str = base.Request.QueryString["id"];
			string text = base.Request.QueryString["parentid"];
			string empty = string.Empty;
			string empty2 = string.Empty;
			string text2 = string.Empty;
			string empty3 = string.Empty;
			string text3 = string.Empty;
			string empty4 = string.Empty;
			Guid test;
			if (str.IsGuid(out test))
			{
				users2 = users.Get(test);
				if (users2 != null)
				{
					empty = users2.Name;
					empty2 = users2.Account;
					text2 = users2.Status.ToString();
					empty3 = users2.Note;
					text3 = users2.Sex.ToString();
					StringBuilder stringBuilder = new StringBuilder();
					foreach (RoadFlow.Data.Model.UsersRelation item in from p in usersRelation.GetAllByUserID(users2.ID)
					orderby p.IsMain descending
					select p)
					{
						stringBuilder.Append("<div style='margin:3px 0;'>");
						stringBuilder.Append(organize.GetAllParentNames(item.OrganizeID, true));
						if (item.IsMain == 0)
						{
							stringBuilder.Append("<span style='color:#999'> [兼任]</span>");
						}
						stringBuilder.Append("</div>");
					}
					base.ViewBag.ParentString = stringBuilder.ToString();
					base.ViewBag.RoleString = new RoadFlow.Platform.WorkGroup().GetAllNamesByUserID(users2.ID);
				}
			}
			Guid test2;
			if (text.IsGuid(out test2))
			{
				organize2 = organize.Get(test2);
			}
			if (collection != null)
			{
				if (!base.Request.Form["Save"].IsNullOrEmpty() && users2 != null)
				{
					empty = base.Request.Form["Name"];
					empty2 = base.Request.Form["Account"];
					text2 = base.Request.Form["Status"];
					empty3 = base.Request.Form["Note"];
					string str2 = base.Request.Form["Tel"];
					string str3 = base.Request.Form["Mobile"];
					string str4 = base.Request.Form["WeiXin"];
					string str5 = base.Request.Form["Email"];
					string str6 = base.Request.Form["Fax"];
					string str7 = base.Request.Form["QQ"];
					string str8 = base.Request.Form["OtherTel"];
					text3 = base.Request.Form["Sex"];
					string oldXML = users2.Serialize();
					users2.Name = empty.Trim();
					users2.Account = empty2.Trim();
					users2.Status = text2.ToInt(1);
					users2.Note = (empty3.IsNullOrEmpty() ? null : empty3.Trim());
					users2.Tel = str2.Trim1();
					users2.Mobile = str3.Trim1();
					users2.WeiXin = str4.Trim1();
					users2.WeiXin = str4.Trim1();
					users2.Email = str5.Trim1();
					users2.Fax = str6.Trim1();
					users2.QQ = str7.Trim1();
					users2.OtherTel = str8.Trim1();
					if (text3.IsInt())
					{
						users2.Sex = text3.ToInt();
					}
					users.Update(users2);
					if (RoadFlow.Platform.WeiXin.Config.IsUse)
					{
						new RoadFlow.Platform.WeiXin.Organize().EditUserAsync(users2);
					}
					new RoadFlow.Platform.MenuUser().ClearCache();
					RoadFlow.Platform.Log.Add("修改了用户", "", RoadFlow.Platform.Log.Types.组织机构, oldXML, users2.Serialize());
					base.ViewBag.Script = "alert('保存成功!');parent.frames[0].reLoad('" + text + "');";
				}
				if (!base.Request.Form["DeleteBut"].IsNullOrEmpty() && users2 != null && organize2 != null)
				{
					using (TransactionScope transactionScope = new TransactionScope())
					{
						List<RoadFlow.Data.Model.UsersRelation> allByUserID = usersRelation.GetAllByUserID(users2.ID);
						users.Delete(users2.ID);
						usersRelation.DeleteByUserID(users2.ID);
						foreach (RoadFlow.Data.Model.UsersRelation item2 in allByUserID)
						{
							organize.UpdateChildsLength(item2.OrganizeID);
						}
						if (RoadFlow.Platform.WeiXin.Config.IsUse)
						{
							new RoadFlow.Platform.WeiXin.Organize().DeleteUserAsync(users2.Account);
						}
						transactionScope.Complete();
					}
					new RoadFlow.Platform.MenuUser().ClearCache();
					new RoadFlow.Platform.HomeItems().ClearCache();
					string text4 = text;
					string text5 = string.Empty;
					List<RoadFlow.Data.Model.Users> allUsers = organize.GetAllUsers(text4);
					if (allUsers.Count > 0)
					{
						text5 = "User?id=" + allUsers.Last().ID + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&parentid=" + text;
					}
					else if (organize2 != null)
					{
						text4 = ((organize2.ParentID == Guid.Empty) ? organize2.ID.ToString() : organize2.ParentID.ToString());
						text5 = "Body?id=" + text + "&appid=" + base.Request.QueryString["appid"] + "&tabid=" + base.Request.QueryString["tabid"] + "&parentid=" + organize2.ParentID;
					}
					RoadFlow.Platform.Log.Add("删除了用户", users2.Serialize(), RoadFlow.Platform.Log.Types.组织机构);
					base.ViewBag.Script = "alert('删除成功');parent.frames[0].reLoad('" + text4 + "');window.location='" + text5 + "'";
				}
				if (!base.Request.Form["InitPass"].IsNullOrEmpty() && users2 != null)
				{
					string initPassword = users.GetInitPassword();
					users.InitPassword(users2.ID);
					RoadFlow.Platform.Log.Add("初始化了用户密码", users2.Serialize(), RoadFlow.Platform.Log.Types.组织机构);
					base.ViewBag.Script = "alert('密码已初始化为：" + initPassword + "');";
				}
				if (!base.Request.Form["Move1"].IsNullOrEmpty() && users2 != null)
				{
					string text6 = base.Request.Form["movetostation"];
					string b = base.Request.Form["movetostationjz"];
					Guid test3;
					if (text6.IsGuid(out test3))
					{
						using (TransactionScope transactionScope2 = new TransactionScope())
						{
							List<RoadFlow.Data.Model.UsersRelation> allByUserID2 = usersRelation.GetAllByUserID(users2.ID);
							if ("1" != b)
							{
								usersRelation.DeleteByUserID(users2.ID);
							}
							usersRelation.Add(new RoadFlow.Data.Model.UsersRelation
							{
								UserID = users2.ID,
								OrganizeID = test3,
								IsMain = ((!("1" == b)) ? 1 : 0),
								Sort = usersRelation.GetMaxSort(test3)
							});
							foreach (RoadFlow.Data.Model.UsersRelation item3 in allByUserID2)
							{
								organize.UpdateChildsLength(item3.OrganizeID);
							}
							organize.UpdateChildsLength(test2);
							organize.UpdateChildsLength(test3);
							new RoadFlow.Platform.MenuUser().ClearCache();
							new RoadFlow.Platform.HomeItems().ClearCache();
							new RoadFlow.Platform.DocumentDirectory().ClearAllDirUsersCache();
							if (RoadFlow.Platform.WeiXin.Config.IsUse)
							{
								new RoadFlow.Platform.WeiXin.Organize().EditUserAsync(users2);
							}
							transactionScope2.Complete();
							base.ViewBag.Script = "alert('调动成功!');parent.frames[0].reLoad('" + text + "');parent.frames[0].reLoad('" + text6 + "')";
						}
						RoadFlow.Platform.Log.Add((("1" == b) ? "兼职" : "全职") + "调动了人员的岗位", "将人员调往岗位(" + text6 + ")", RoadFlow.Platform.Log.Types.组织机构);
					}
				}
			}
			base.ViewBag.StatusRadios = organize.GetStatusRadio("Status", text2, "validate=\"radio\"");
			base.ViewBag.SexRadios = organize.GetSexRadio("Sex", text3, "validate=\"radio\"");
			return View(users2);
		}

		public ActionResult Sort()
		{
			return Sort(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Sort(FormCollection collection)
		{
			string text = base.Request.QueryString["parentid"];
			if (collection != null)
			{
				string[] array = (base.Request.Form["sort"] ?? "").Split(',');
				RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
				for (int i = 0; i < array.Length; i++)
				{
					Guid test;
					if (array[i].IsGuid(out test))
					{
						organize.UpdateSort(test, i + 1);
					}
				}
				base.ViewBag.Script = "parent.frames[0].reLoad('" + text + "');";
			}
			List<RoadFlow.Data.Model.Organize> childs = new RoadFlow.Platform.Organize().GetChilds(text.ToGuid());
			return View(childs);
		}

		public ActionResult SortUsers()
		{
			return SortUsers(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SortUsers(FormCollection collection)
		{
			string text = base.Request.QueryString["parentid"];
			if (collection != null)
			{
				string[] array = (base.Request.Form["sort"] ?? "").Split(',');
				RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
				for (int i = 0; i < array.Length; i++)
				{
					Guid test;
					if (array[i].IsGuid(out test))
					{
						users.UpdateSort(test, i + 1);
					}
				}
				base.ViewBag.Script = "parent.frames[0].reLoad('" + text + "');";
			}
			List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(text.ToGuid());
			return View(allUsers);
		}

		[MyAttribute(CheckApp = false)]
		public string GetPy()
		{
			string text = base.Request.Form["name"].ToChineseSpell();
			if (!text.IsNullOrEmpty())
			{
				return new RoadFlow.Platform.Users().GetAccount(text.Trim());
			}
			return "";
		}

		[MyAttribute(CheckApp = false)]
		public string CheckAccount()
		{
			string msg;
			if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			string account = base.Request.Form["value"];
			string userID = base.Request["id"];
			if (!new RoadFlow.Platform.Users().HasAccount(account, userID))
			{
				return "1";
			}
			return "帐号已经被使用了";
		}

		[MyAttribute(CheckApp = false)]
		public string GetNames()
		{
			string msg;
			if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			string idString = base.Request.QueryString["values"];
			return new RoadFlow.Platform.Organize().GetNames(idString);
		}

		[MyAttribute(CheckApp = false)]
		public string GetNote()
		{
			string msg;
			if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			string text = base.Request.QueryString["id"];
			if (text.IsNullOrEmpty())
			{
				return "";
			}
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			if (text.StartsWith("u_"))
			{
				Guid guid = users.RemovePrefix1(text).ToGuid();
				return organize.GetAllParentNames(users.GetMainStation(guid)) + " / " + users.GetName(guid);
			}
			if (text.StartsWith("w_"))
			{
				return new RoadFlow.Platform.WorkGroup().GetUsersNames(RoadFlow.Platform.WorkGroup.RemovePrefix(text).ToGuid(), '、');
			}
			Guid test;
			if (text.IsGuid(out test))
			{
				return organize.GetAllParentNames(test);
			}
			return "";
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult EditPass()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult EditPass(FormCollection collection)
		{
			string text = base.Request.Form["oldpass"];
			string text2 = base.Request.Form["newpass"];
			RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
			RoadFlow.Data.Model.Users currentUser = RoadFlow.Platform.Users.CurrentUser;
			if (currentUser != null)
			{
				if (string.Compare(currentUser.Password, users.GetUserEncryptionPassword(currentUser.ID.ToString(), text.Trim()), false) != 0)
				{
					RoadFlow.Platform.Log.Add("修改密码失败", "用户：" + currentUser.Name + "(" + currentUser.ID + ")修改密码失败,旧密码错误!", RoadFlow.Platform.Log.Types.用户登录);
					base.ViewBag.Script = "alert('旧密码错误!');";
				}
				else
				{
					users.UpdatePassword(text2.Trim(), currentUser.ID);
					RoadFlow.Platform.Log.Add("修改密码成功", "用户：" + currentUser.Name + "(" + currentUser.ID + ")修改密码成功!", RoadFlow.Platform.Log.Types.用户登录);
					base.ViewBag.Script = "alert('密码修改成功!');new RoadUI.Window().close();";
				}
			}
			return View();
		}

		public ActionResult WorkGroup()
		{
			return WorkGroup(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult WorkGroup(FormCollection collection)
		{
			string str = base.Request.QueryString["id"];
			RoadFlow.Platform.WorkGroup workGroup = new RoadFlow.Platform.WorkGroup();
			RoadFlow.Data.Model.WorkGroup workGroup2 = null;
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			Guid test;
			if (!str.IsGuid(out test) || test == Guid.Empty)
			{
				base.Response.End();
				return null;
			}
			workGroup2 = workGroup.Get(test);
			string text = string.Empty;
			if (workGroup2 != null)
			{
				text = workGroup2.Members;
				empty = workGroup2.Name;
				empty2 = workGroup2.Members;
				empty3 = workGroup2.Note;
				workGroup.GetUsersNames(workGroup2.Members, '、');
			}
			if (!base.Request.Form["Save"].IsNullOrEmpty() && collection != null && workGroup2 != null)
			{
				string oldXML = workGroup2.Serialize();
				empty = base.Request.Form["Name"];
				empty2 = base.Request.Form["Members"];
				empty3 = base.Request.Form["Note"];
				workGroup2.Name = empty.Trim();
				workGroup2.Members = empty2;
				if (!empty3.IsNullOrEmpty())
				{
					workGroup2.Note = empty3;
				}
				workGroup2.IntID = workGroup2.ID.ToInt32();
				workGroup.Update(workGroup2);
				if (RoadFlow.Platform.WeiXin.Config.IsUse)
				{
					RoadFlow.Platform.WeiXin.Organize organize = new RoadFlow.Platform.WeiXin.Organize();
					organize.EditGroupAsync(workGroup2);
					if (!text.Equals(workGroup2.Members, StringComparison.CurrentCultureIgnoreCase))
					{
						organize.AddGroupUserAsync(workGroup2);
					}
				}
				new RoadFlow.Platform.MenuUser().ClearCache();
				new RoadFlow.Platform.HomeItems().ClearCache();
				workGroup.GetUsersNames(workGroup2.Members, '、');
				string query2 = base.Request.Url.Query;
				RoadFlow.Platform.Log.Add("修改了工作组", "修改了工作组", RoadFlow.Platform.Log.Types.组织机构, oldXML, workGroup2.Serialize());
				base.ViewBag.Script = "alert('保存成功!');";
			}
			if (!base.Request.Form["DeleteBut"].IsNullOrEmpty() && collection != null && workGroup2 != null)
			{
				string contents = workGroup2.Serialize();
				workGroup.Delete(workGroup2.ID);
				if (RoadFlow.Platform.WeiXin.Config.IsUse)
				{
					new RoadFlow.Platform.WeiXin.Organize().DeleteGroupAsync(workGroup2);
				}
				new RoadFlow.Platform.MenuUser().ClearCache();
				new RoadFlow.Platform.HomeItems().ClearCache();
				string query = base.Request.Url.Query;
				RoadFlow.Platform.Log.Add("删除了工作组", contents, RoadFlow.Platform.Log.Types.组织机构);
				base.ViewBag.Script = "parent.frames[0].treecng('1');alert('删除成功!');window.location = 'Empty' + '" + query + "';";
			}
			return View(workGroup2);
		}

		public ActionResult WorkGroupAdd()
		{
			return WorkGroupAdd(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult WorkGroupAdd(FormCollection collection)
		{
			RoadFlow.Platform.WorkGroup workGroup = new RoadFlow.Platform.WorkGroup();
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			if (collection != null)
			{
				empty = base.Request.Form["Name"];
				empty2 = base.Request.Form["Members"];
				empty3 = base.Request.Form["Note"];
				RoadFlow.Data.Model.WorkGroup workGroup2 = new RoadFlow.Data.Model.WorkGroup();
				workGroup2.ID = Guid.NewGuid();
				workGroup2.Name = empty.Trim();
				workGroup2.Members = empty2;
				if (!empty3.IsNullOrEmpty())
				{
					workGroup2.Note = empty3;
				}
				workGroup2.IntID = workGroup2.ID.ToInt32();
				workGroup.Add(workGroup2);
				if (RoadFlow.Platform.WeiXin.Config.IsUse)
				{
					new RoadFlow.Platform.WeiXin.Organize().AddGroupAsync(workGroup2);
				}
				new RoadFlow.Platform.MenuUser().ClearCache();
				string query = base.Request.Url.Query;
				RoadFlow.Platform.Log.Add("添加了工作组", workGroup2.Serialize(), RoadFlow.Platform.Log.Types.组织机构);
				base.ViewBag.Script = "parent.frames[0].treecng('1');alert('添加成功!');window.location = 'WorkGroup' + '" + query + "';";
			}
			return View();
		}

		public ActionResult SetMenu()
		{
			return SetMenu(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SetMenu(FormCollection collection)
		{
			RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
			RoadFlow.Platform.MenuUser menuUser = new RoadFlow.Platform.MenuUser();
			string text = base.Request.QueryString["id"];
			string b = base.Request.QueryString["type"];
			string text2 = (("4" == b) ? "u_" : (("5" == b) ? "w_" : "")) + text;
			if (collection != null)
			{
				string text3 = base.Request.Form["menuid"] ?? "";
				RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
				menuUser.ClearCache();
				string users = organize.GetAllUsersIdList(text2).ToArray().Join1();
				using (TransactionScope transactionScope = new TransactionScope())
				{
					menuUser.DeleteByOrganizes(text2);
					string[] array = text3.Split(',');
					foreach (string text4 in array)
					{
						if (text4.IsGuid())
						{
							RoadFlow.Data.Model.MenuUser menuUser2 = new RoadFlow.Data.Model.MenuUser();
							menuUser2.Buttons = (base.Request.Form["button_" + text4] ?? "");
							menuUser2.SubPageID = Guid.Empty;
							menuUser2.ID = Guid.NewGuid();
							menuUser2.MenuID = text4.ToGuid();
							menuUser2.Organizes = text2;
							menuUser2.Users = users;
							menuUser2.Params = (base.Request.Form["params_" + text4] ?? "").Replace("\"", "");
							menuUser.Add(menuUser2);
							string[] array2 = (base.Request.Form["subpage_" + text4] ?? "").Split(',');
							foreach (string text5 in array2)
							{
								if (text5.IsGuid())
								{
									RoadFlow.Data.Model.MenuUser menuUser3 = new RoadFlow.Data.Model.MenuUser();
									menuUser3.Buttons = (base.Request.Form["button_" + text4 + "_" + text5] ?? "");
									menuUser3.SubPageID = text5.ToGuid();
									menuUser3.ID = Guid.NewGuid();
									menuUser3.MenuID = menuUser2.MenuID;
									menuUser3.Organizes = text2;
									menuUser3.Users = users;
									menuUser.Add(menuUser3);
								}
							}
						}
					}
					transactionScope.Complete();
					base.ViewBag.script = "alert('保存成功!');window.location=window.location;";
				}
				menuUser.ClearCache();
			}
			string menuTreeTableHtml = menu.GetMenuTreeTableHtml(text);
			base.ViewBag.menuhtml = menuTreeTableHtml;
			return View();
		}

		public ActionResult ShowMenu()
		{
			return View();
		}
	}
}
