using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RoadFlow.Platform
{
	public class MenuUser
	{
		private static readonly string cachekey = 0.ToString() + "_MenuUsers";

		private IMenuUser dataMenuUser;

		public MenuUser()
		{
			dataMenuUser = Factory.GetMenuUser();
		}

		public int Add(RoadFlow.Data.Model.MenuUser model)
		{
			return dataMenuUser.Add(model);
		}

		public int Update(RoadFlow.Data.Model.MenuUser model)
		{
			return dataMenuUser.Update(model);
		}

		public List<RoadFlow.Data.Model.MenuUser> GetAll(bool cache = true)
		{
			if (!cache)
			{
				Organize organize = new Organize();
				List<RoadFlow.Data.Model.MenuUser> all = dataMenuUser.GetAll();
				{
					foreach (RoadFlow.Data.Model.MenuUser item in all)
					{
						item.Users = organize.GetAllUsersIdString(item.Organizes);
					}
					return all;
				}
			}
			object obj = Opation.Get(cachekey);
			if (obj == null)
			{
				Organize organize2 = new Organize();
				List<RoadFlow.Data.Model.MenuUser> all2 = dataMenuUser.GetAll();
				foreach (RoadFlow.Data.Model.MenuUser item2 in all2)
				{
					item2.Users = organize2.GetAllUsersIdString(item2.Organizes);
				}
				Opation.Set(cachekey, all2);
				return all2;
			}
			return (List<RoadFlow.Data.Model.MenuUser>)obj;
		}

		public RoadFlow.Data.Model.MenuUser Get(Guid id)
		{
			return dataMenuUser.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataMenuUser.Delete(id);
		}

		public long GetCount()
		{
			return dataMenuUser.GetCount();
		}

		public int DeleteByOrganizes(string organizes)
		{
			return dataMenuUser.DeleteByOrganizes(organizes);
		}

		public void ClearCache()
		{
			Opation.Remove(cachekey);
		}

		public void RefreshUsers()
		{
			MenuUser menuUser = new MenuUser();
			Organize organize = new Organize();
			foreach (RoadFlow.Data.Model.MenuUser item in menuUser.GetAll(false))
			{
				item.Users = organize.GetAllUsersIdList(item.Organizes).ToArray().Join1();
				menuUser.Update(item);
			}
			ClearCache();
		}

		public static Dictionary<int, string> getButtonsHtml(string menuID = "", string subpageID = "", string programID = "")
		{
			Guid menuID2;
			if (menuID.IsNullOrEmpty() || !menuID.IsGuid(out menuID2))
			{
				menuID2 = HttpContext.Current.Request.QueryString["appid"].ToGuid();
			}
			Guid subpageID2;
			if (!subpageID.IsGuid(out subpageID2))
			{
				subpageID2 = HttpContext.Current.Request.QueryString["subpageid"].ToGuid();
			}
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			dictionary.Add(0, "");
			dictionary.Add(1, "");
			dictionary.Add(2, "");
			string str = HttpContext.Current.Request.QueryString["applibaryid"];
			List<Guid> list = new List<Guid>();
			if (str.IsGuid())
			{
				foreach (RoadFlow.Data.Model.AppLibraryButtons1 item in new AppLibraryButtons1().GetAllByAppID(str.ToGuid()).FindAll((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.IsValidateShow == 1))
				{
					list.Add(item.ID);
				}
			}
			else
			{
				foreach (RoadFlow.Data.Model.MenuUser item2 in new MenuUser().GetAll().FindAll(delegate(RoadFlow.Data.Model.MenuUser p)
				{
					if (p.MenuID == menuID2 && p.SubPageID == subpageID2)
					{
						return p.Users.Contains(Users.CurrentUserID.ToString(), StringComparison.CurrentCultureIgnoreCase);
					}
					return false;
				}))
				{
					string[] array = item2.Buttons.Split(',');
					for (int i = 0; i < array.Length; i++)
					{
						Guid test;
						if (array[i].IsGuid(out test) && !list.Contains(test))
						{
							list.Add(test);
						}
					}
				}
			}
			List<RoadFlow.Data.Model.AppLibraryButtons1> list2 = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
			RoadFlow.Data.Model.AppLibrary byCode = new AppLibrary().GetByCode(programID);
			if (byCode != null)
			{
				list2.AddRange(new AppLibraryButtons1().GetAllByAppID(byCode.ID).FindAll((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.IsValidateShow == 0));
			}
			if (list.Count == 0 && list2.Count == 0)
			{
				return dictionary;
			}
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			StringBuilder stringBuilder3 = new StringBuilder();
			AppLibraryButtons1 appLibraryButtons = new AppLibraryButtons1();
			foreach (Guid item3 in list)
			{
				RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons2 = appLibraryButtons.Get(item3, true);
				if (appLibraryButtons2 != null && appLibraryButtons2.IsValidateShow != 0)
				{
					list2.Add(appLibraryButtons2);
				}
			}
			foreach (RoadFlow.Data.Model.AppLibraryButtons1 item4 in from p in list2
			orderby p.Sort
			select p)
			{
				string userID = Users.CurrentUserID.ToString();
				if (item4.ShowType == 0)
				{
					string text = "fun_" + Guid.NewGuid().ToString("N");
					stringBuilder.Append("<a href=\"javascript:void(0);\" onclick=\"" + text + "();return false;\"><span style=\"" + ((!item4.Ico.IsNullOrEmpty() && !item4.Ico.IsFontIco()) ? ("background-image:url(" + Config.BaseUrl + item4.Ico + ");") : "padding-left:0px;") + "\">" + ((!item4.Ico.IsNullOrEmpty() && item4.Ico.IsFontIco()) ? ("<i class='fa " + item4.Ico + "' style='font-size:14px;vertical-align:middle;margin-right:3px;'></i>") : "") + item4.Name + "</span></a>");
					stringBuilder.Append("<script type=\"text/javascript\">function " + text + "(){" + item4.Events.FilterWildcard(userID) + "}</script>");
				}
				else if (item4.ShowType == 1)
				{
					string text2 = "fun_" + Guid.NewGuid().ToString("N");
					stringBuilder2.Append("<button type=\"button\" " + (item4.Ico.IsNullOrEmpty() ? "style=\"margin-left:6px;\"" : ("style=\"margin-left:6px;" + ((!item4.Ico.IsNullOrEmpty() && !item4.Ico.IsFontIco()) ? ("background-image:url(" + Config.BaseUrl + item4.Ico + ");background-repeat:no-repeat;background-position-y:center;background-position-x:8px;padding-left:28px;") : "") + "\"")) + " onclick=\"" + text2 + "();return false;\" class=\"mybutton\">");
					if (!item4.Ico.IsNullOrEmpty() && item4.Ico.IsFontIco())
					{
						stringBuilder2.Append("<i class=\"fa " + item4.Ico + "\" style=\"font-size:14px;vertical-align:middle;margin-right:3px;\"></i>");
					}
					stringBuilder2.Append("<span style=\"vertical-align:middle;\">" + item4.Name + "</span>");
					stringBuilder2.Append("</button>");
					stringBuilder2.Append("<script type=\"text/javascript\">function " + text2 + "(){" + item4.Events.FilterWildcard(userID) + "}</script>");
				}
				else if (item4.ShowType == 2)
				{
					string text3 = "fun_" + Guid.NewGuid().ToString("N");
					stringBuilder3.Append("<a href=\"javascript:void(0);\" onclick=\"" + item4.Events + ";return false;\" " + (item4.Ico.IsNullOrEmpty() ? "style=\"margin-left:0px;\"" : ("style=\"margin-left:0px;" + ((!item4.Ico.IsFontIco()) ? ("padding-left:26px;background-image:url(" + Config.BaseUrl + item4.Ico + ");background-repeat:no-repeat;background-position-y:center;background-position-x:8px;") : "") + "\"")) + ">" + ((!item4.Ico.IsNullOrEmpty() && item4.Ico.IsFontIco()) ? ("<i class='fa " + item4.Ico + "' style='font-size:14px;vertical-align:middle;margin-right:3px;padding-left:10px;'></i>") : "") + item4.Name + "</a>");
				}
			}
			dictionary[0] = ((stringBuilder.Length > 0) ? ("<div class=\"toolbar\" style=\"margin-top:0; border-top:none 0; position:fixed; top:0; left:0; right:0; margin-left:auto; z-index:999; width:100%; margin-right:auto;\">" + stringBuilder.ToString() + "</div>") : "");
			dictionary[1] = stringBuilder2.ToString();
			dictionary[2] = stringBuilder3.ToString();
			return dictionary;
		}

		public int DeleteByMenuID(Guid menuID)
		{
			return dataMenuUser.DeleteByMenuID(menuID);
		}
	}
}
