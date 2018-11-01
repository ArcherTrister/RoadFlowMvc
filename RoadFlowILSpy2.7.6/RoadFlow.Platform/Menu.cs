using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
	public class Menu
	{
		private IMenu dataMenu;

		public Menu()
		{
			dataMenu = Factory.GetMenu();
		}

		public int Add(RoadFlow.Data.Model.Menu model)
		{
			ClearAllDataTableCache();
			return dataMenu.Add(model);
		}

		public int Update(RoadFlow.Data.Model.Menu model)
		{
			ClearAllDataTableCache();
			return dataMenu.Update(model);
		}

		public List<RoadFlow.Data.Model.Menu> GetAll()
		{
			return dataMenu.GetAll();
		}

		public RoadFlow.Data.Model.Menu Get(Guid id)
		{
			return dataMenu.Get(id);
		}

		public DataRow GetFromCache(Guid id)
		{
			DataRow[] array = GetAllDataTable().Select("ID='" + id + "'");
			if (array.Length == 0)
			{
				return null;
			}
			return array[0];
		}

		public int Delete(Guid id)
		{
			ClearAllDataTableCache();
			return dataMenu.Delete(id);
		}

		public long GetCount()
		{
			return dataMenu.GetCount();
		}

		public void ClearAllDataTableCache()
		{
			Opation.Remove(0.ToString());
		}

		public DataTable GetAllDataTable(bool cache = true)
		{
			if (!cache)
			{
				return dataMenu.GetAllDataTable();
			}
			string key = 0.ToString();
			object obj = Opation.Get(key);
			if (obj == null || !(obj is DataTable))
			{
				DataTable allDataTable = dataMenu.GetAllDataTable();
				Opation.Set(key, allDataTable);
				return allDataTable;
			}
			return (DataTable)obj;
		}

		public List<RoadFlow.Data.Model.Menu> GetChild(Guid id)
		{
			return dataMenu.GetChild(id);
		}

		public bool HasChild(Guid id)
		{
			return dataMenu.HasChild(id);
		}

		public int UpdateSort(Guid id, int sort)
		{
			return dataMenu.UpdateSort(id, sort);
		}

		public List<RoadFlow.Data.Model.Menu> GetAllChild(Guid id)
		{
			List<RoadFlow.Data.Model.Menu> list = new List<RoadFlow.Data.Model.Menu>();
			foreach (RoadFlow.Data.Model.Menu item in GetChild(id))
			{
				list.Add(item);
				addChilds(list, item.ID);
			}
			return list;
		}

		private void addChilds(List<RoadFlow.Data.Model.Menu> list, Guid id)
		{
			foreach (RoadFlow.Data.Model.Menu item in GetChild(id))
			{
				list.Add(item);
				addChilds(list, item.ID);
			}
		}

		public int DeleteAndAllChilds(Guid id)
		{
			List<RoadFlow.Data.Model.Menu> allChild = GetAllChild(id);
			int num = 0;
			foreach (RoadFlow.Data.Model.Menu item in allChild)
			{
				num += Delete(item.ID);
			}
			num += Delete(id);
			ClearAllDataTableCache();
			return num;
		}

		public int GetMaxSort(Guid id)
		{
			return dataMenu.GetMaxSort(id);
		}

		private string getAddress(DataRow dr, string paramsMenuUsers = "")
		{
			string text = dr["Address"].ToString().Trim();
			string text2 = dr["Params"].ToString().Trim();
			string text3 = dr["Params1"].ToString().Trim();
			StringBuilder stringBuilder = new StringBuilder();
			if (text2.IsNullOrEmpty() && text3.IsNullOrEmpty() && paramsMenuUsers.IsNullOrEmpty())
			{
				return text;
			}
			if (!text3.IsNullOrEmpty())
			{
				stringBuilder.Append(text3.TrimStart('?').TrimStart('&').TrimEnd('&')
					.TrimEnd('?'));
			}
			if (!text2.IsNullOrEmpty())
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('&');
				}
				stringBuilder.Append(text2.TrimStart('?').TrimStart('&').TrimEnd('&')
					.TrimEnd('?'));
			}
			if (!paramsMenuUsers.IsNullOrEmpty())
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('&');
				}
				stringBuilder.Append(paramsMenuUsers.TrimStart('?').TrimStart('&').TrimEnd('&')
					.TrimEnd('?'));
			}
			return (text.Contains("?") ? (text + "&" + stringBuilder.ToString()) : (text + "?" + stringBuilder.ToString())).FilterWildcard(Users.CurrentUserID.ToString());
		}

		public string GetUserMenu(Guid userID)
		{
			Menu menu = new Menu();
			new AppLibrary();
			DataTable allDataTable = menu.GetAllDataTable();
			if (allDataTable.Rows.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			string source = string.Empty;
			List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll();
			foreach (RoadFlow.Data.Model.UserShortcut item in new UserShortcut().GetAllByUserID(userID, true))
			{
				string @params = string.Empty;
				List<RoadFlow.Data.Model.MenuUser> list = all.FindAll(delegate(RoadFlow.Data.Model.MenuUser p)
				{
					if (p.MenuID == item.MenuID && p.SubPageID == Guid.Empty)
					{
						return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
					}
					return false;
				});
				if (list.Count > 0)
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					foreach (IGrouping<string, RoadFlow.Data.Model.MenuUser> item2 in from p in list.FindAll((RoadFlow.Data.Model.MenuUser p) => !p.Params.IsNullOrEmpty())
					group p by p.Params)
					{
						stringBuilder2.Append(item2.Key.Trim1());
						stringBuilder2.Append("&");
					}
					@params = stringBuilder2.ToString().TrimEnd('&');
				}
				if (HasUse(item.MenuID, userID, all, out source, out @params))
				{
					DataRow[] array = allDataTable.Select(string.Format("ID='{0}'", item.MenuID.ToString()));
					if (array.Length != 0)
					{
						DataRow dataRow = array[0];
						string str = dataRow["IcoColor"].ToString();
						if (str.IsNullOrEmpty())
						{
							str = dataRow["IcoColor1"].ToString();
						}
						DataRow[] array2 = allDataTable.Select("ParentID='" + dataRow["ID"].ToString() + "'");
						stringBuilder.Append("<div class=\"menulistdiv\" onclick=\"menuClick(this);\" data-id=\"" + dataRow["ID"].ToString() + "\" data-title=\"" + dataRow["Title"].ToString().Trim() + "\" data-model=\"" + dataRow["OpenMode"].ToString() + "\" data-width=\"" + dataRow["Width"].ToString() + "\" data-height=\"" + dataRow["Height"].ToString() + "\" data-childs=\"" + ((array2.Length != 0) ? "1" : "0") + "\" data-url=\"" + getAddress(dataRow, @params) + "\" data-parent=\"" + Guid.Empty.ToString() + "\" style=\"" + (str.IsNullOrEmpty() ? "" : ("color:" + str.Trim1() + ";")) + "\">");
						stringBuilder.Append("<div class=\"menulistdiv1\">");
						string text = dataRow["Ico"].ToString();
						if (text.IsNullOrEmpty())
						{
							text = dataRow["AppIco"].ToString();
						}
						if (text.IsNullOrEmpty())
						{
							stringBuilder.Append("<i class=\"fa fa-list-ul\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
						}
						else if (text.IsFontIco())
						{
							stringBuilder.Append("<i class=\"fa " + text + "\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
						}
						else
						{
							stringBuilder.Append("<img src=\"" + Config.BaseUrl + text + "\" style=\"vertical-align:middle\" alt=\"\"/>");
						}
						stringBuilder.Append("<span style=\"vertical-align:middle\">" + dataRow["Title"].ToString().Trim1() + "</span>");
						stringBuilder.Append("</div>");
						if (array2.Length != 0)
						{
							stringBuilder.Append("<div class=\"menulistdiv2\"><i class=\"fa fa-angle-left\"></i></div>");
						}
						stringBuilder.Append("</div>");
					}
				}
			}
			DataRow[] array3 = allDataTable.Select(string.Format("ParentID='{0}'", Guid.Empty.ToString()));
			if (array3.Length == 0)
			{
				return stringBuilder.ToString();
			}
			DataRow[] array4 = allDataTable.Select(string.Format("ParentID='{0}'", array3[0]["ID"].ToString()));
			for (int i = 0; i < array4.Length; i++)
			{
				string params2 = string.Empty;
				DataRow dataRow2 = array4[i];
				if (HasUse(dataRow2["ID"].ToString().ToGuid(), userID, all, out source, out params2))
				{
					DataRow[] array5 = allDataTable.Select("ParentID='" + dataRow2["ID"].ToString() + "'");
					bool flag = false;
					DataRow[] array6 = array5;
					foreach (DataRow dataRow3 in array6)
					{
						if (HasUse(dataRow3["ID"].ToString().ToGuid(), userID, all, out source, out params2))
						{
							flag = true;
							break;
						}
					}
					string str2 = dataRow2["IcoColor"].ToString();
					if (str2.IsNullOrEmpty())
					{
						str2 = dataRow2["IcoColor1"].ToString();
					}
					stringBuilder.Append("<div class=\"menulistdiv\" onclick=\"menuClick(this);\" data-id=\"" + dataRow2["ID"].ToString() + "\" data-title=\"" + dataRow2["Title"].ToString().Trim() + "\" data-model=\"" + dataRow2["OpenMode"].ToString() + "\" data-width=\"" + dataRow2["Width"].ToString() + "\" data-height=\"" + dataRow2["Height"].ToString() + "\" data-childs=\"" + (flag ? "1" : "0") + "\" data-url=\"" + getAddress(dataRow2, params2) + "\" data-parent=\"" + Guid.Empty.ToString() + "\" style=\"" + (str2.IsNullOrEmpty() ? "" : ("color:" + str2.Trim1() + ";")) + "\">");
					stringBuilder.Append("<div class=\"menulistdiv1\">");
					string text2 = dataRow2["Ico"].ToString();
					if (text2.IsNullOrEmpty())
					{
						text2 = dataRow2["AppIco"].ToString();
					}
					if (text2.IsNullOrEmpty())
					{
						stringBuilder.Append("<i class=\"fa fa-th-list\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
					}
					else if (text2.IsFontIco())
					{
						stringBuilder.Append("<i class=\"fa " + text2 + "\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
					}
					else
					{
						stringBuilder.Append("<img src=\"" + Config.BaseUrl + text2 + "\" style=\"vertical-align:middle\" alt=\"\"/>");
					}
					stringBuilder.Append("<span style=\"vertical-align:middle\">" + dataRow2["Title"].ToString().Trim1() + "</span>");
					stringBuilder.Append("</div>");
					if (flag)
					{
						stringBuilder.Append("<div class=\"menulistdiv2\"><i class=\"fa fa-angle-left\"></i></div>");
					}
					stringBuilder.Append("</div>");
				}
			}
			return stringBuilder.ToString();
		}

		public string GetUserMenuChilds(Guid userID, Guid refreshID, string rootDir = "", string isrefresh1 = "0")
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataTable allDataTable = GetAllDataTable();
			DataView defaultView = allDataTable.DefaultView;
			defaultView.RowFilter = string.Format("ParentID='{0}'", refreshID);
			defaultView.Sort = "Sort";
			DataTable dataTable = defaultView.ToTable();
			if (dataTable.Rows.Count == 0)
			{
				return "[]";
			}
			int count = dataTable.Rows.Count;
			new StringBuilder("[", count * 100);
			List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll();
			string source = string.Empty;
			foreach (DataRow row in dataTable.Rows)
			{
				string @params = string.Empty;
				if (HasUse(row["ID"].ToString().ToGuid(), userID, all, out source, out @params))
				{
					DataRow[] array = allDataTable.Select(string.Format("ParentID='{0}'", row["id"].ToString()));
					bool flag = false;
					DataRow[] array2 = array;
					foreach (DataRow dataRow2 in array2)
					{
						if (HasUse(dataRow2["ID"].ToString().ToGuid(), userID, all, out source, out @params))
						{
							flag = true;
							break;
						}
					}
					string str = row["IcoColor"].ToString();
					if (str.IsNullOrEmpty())
					{
						str = row["IcoColor1"].ToString();
					}
					stringBuilder.Append("<div class=\"menulistdiv\" " + (("1" == isrefresh1) ? "data-isrefresh1=\"1\"" : "") + " onclick=\"" + (("1" == isrefresh1) ? "menuClick(this, 1);" : "menuClick(this, 0);") + "\" data-id=\"" + row["ID"].ToString() + "\" data-title=\"" + row["Title"].ToString().Trim() + "\" data-model=\"" + row["OpenMode"].ToString() + "\" data-width=\"" + row["Width"].ToString() + "\" data-height=\"" + row["Height"].ToString() + "\" data-childs=\"" + (flag ? "1" : "0") + "\" data-url=\"" + getAddress(row, @params) + "\" data-parent=\"" + refreshID.ToString() + "\" style=\"" + (str.IsNullOrEmpty() ? "" : ("color:" + str.Trim1() + ";")) + "\">");
					stringBuilder.Append("<div class=\"menulistdiv1\">");
					string text = row["Ico"].ToString();
					if (text.IsNullOrEmpty())
					{
						text = row["AppIco"].ToString();
					}
					if (text.IsNullOrEmpty())
					{
						stringBuilder.Append("<i class=\"fa fa-file-text-o\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
					}
					else if (text.IsFontIco())
					{
						stringBuilder.Append("<i class=\"fa " + text + "\" style=\"font-size:14px;margin-right:3px;vertical-align:middle\"></i>");
					}
					else
					{
						stringBuilder.Append("<img src=\"" + Config.BaseUrl + text + "\" style=\"vertical-align:middle\" alt=\"\"/>");
					}
					stringBuilder.Append("<span style=\"vertical-align:middle\">" + row["Title"].ToString().Trim1() + "</span>");
					stringBuilder.Append("</div>");
					if (flag)
					{
						stringBuilder.Append("<div class=\"menulistdiv2\"><i class=\"fa fa-angle-left\"></i></div>");
					}
					stringBuilder.Append("</div>");
				}
			}
			return stringBuilder.ToString();
		}

		public string GetUserMenu1(Guid userID)
		{
			Menu menu = new Menu();
			new AppLibrary();
			DataTable allDataTable = menu.GetAllDataTable();
			if (allDataTable.Rows.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			string source = string.Empty;
			List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll();
			foreach (RoadFlow.Data.Model.UserShortcut item in new UserShortcut().GetAllByUserID(userID, true))
			{
				string @params = string.Empty;
				List<RoadFlow.Data.Model.MenuUser> list = all.FindAll(delegate(RoadFlow.Data.Model.MenuUser p)
				{
					if (p.MenuID == item.MenuID && p.SubPageID == Guid.Empty)
					{
						return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
					}
					return false;
				});
				if (list.Count > 0)
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					foreach (IGrouping<string, RoadFlow.Data.Model.MenuUser> item2 in from p in list.FindAll((RoadFlow.Data.Model.MenuUser p) => !p.Params.IsNullOrEmpty())
					group p by p.Params)
					{
						stringBuilder2.Append(item2.Key.Trim1());
						stringBuilder2.Append("&");
					}
					@params = stringBuilder2.ToString().TrimEnd('&');
				}
				if (HasUse(item.MenuID, userID, all, out source, out @params))
				{
					DataRow[] array = allDataTable.Select(string.Format("ID='{0}'", item.MenuID.ToString()));
					if (array.Length != 0)
					{
						DataRow dataRow = array[0];
						string str = dataRow["IcoColor"].ToString();
						if (str.IsNullOrEmpty())
						{
							str = dataRow["IcoColor1"].ToString();
						}
						DataRow[] array2 = allDataTable.Select("ParentID='" + dataRow["ID"].ToString() + "'");
						stringBuilder.Append("<div class=\"menulistdiv11\" title=\"" + dataRow["Title"].ToString().Trim1() + "\" onclick=\"menuClick1(this);\" data-id=\"" + dataRow["ID"].ToString() + "\" data-title=\"" + dataRow["Title"].ToString().Trim() + "\" data-model=\"" + dataRow["OpenMode"].ToString() + "\" data-width=\"" + dataRow["Width"].ToString() + "\" data-height=\"" + dataRow["Height"].ToString() + "\" data-childs=\"" + ((array2.Length != 0) ? "1" : "0") + "\" data-url=\"" + getAddress(dataRow, @params) + "\" data-parent=\"" + Guid.Empty.ToString() + "\" style=\"" + (str.IsNullOrEmpty() ? "" : ("color:" + str.Trim1() + ";")) + "\">");
						stringBuilder.Append("<div class=\"menulistdiv1\">");
						string text = dataRow["Ico"].ToString();
						if (text.IsNullOrEmpty())
						{
							text = dataRow["AppIco"].ToString();
						}
						if (text.IsNullOrEmpty())
						{
							stringBuilder.Append("<i class=\"fa fa-list-ul\" style=\"margin-right:3px;vertical-align:middle\"></i>");
						}
						else if (text.IsFontIco())
						{
							stringBuilder.Append("<i class=\"fa " + text + "\" style=\"margin-right:3px;vertical-align:middle\"></i>");
						}
						else
						{
							stringBuilder.Append("<img src=\"" + Config.BaseUrl + text + "\" style=\"vertical-align:middle\" alt=\"\"/>");
						}
						stringBuilder.Append("</div>");
						stringBuilder.Append("</div>");
					}
				}
			}
			DataRow[] array3 = allDataTable.Select(string.Format("ParentID='{0}'", Guid.Empty.ToString()));
			if (array3.Length == 0)
			{
				return stringBuilder.ToString();
			}
			DataRow[] array4 = allDataTable.Select(string.Format("ParentID='{0}'", array3[0]["ID"].ToString()));
			for (int i = 0; i < array4.Length; i++)
			{
				string params2 = string.Empty;
				DataRow dataRow2 = array4[i];
				if (HasUse(dataRow2["ID"].ToString().ToGuid(), userID, all, out source, out params2))
				{
					DataRow[] array5 = allDataTable.Select("ParentID='" + dataRow2["ID"].ToString() + "'");
					bool flag = false;
					DataRow[] array6 = array5;
					foreach (DataRow dataRow3 in array6)
					{
						if (HasUse(dataRow3["ID"].ToString().ToGuid(), userID, all, out source, out params2))
						{
							flag = true;
							break;
						}
					}
					string str2 = dataRow2["IcoColor"].ToString();
					if (str2.IsNullOrEmpty())
					{
						str2 = dataRow2["IcoColor1"].ToString();
					}
					stringBuilder.Append("<div class=\"menulistdiv11\" title=\"" + dataRow2["Title"].ToString().Trim1() + "\" onclick=\"menuClick1(this);\" data-id=\"" + dataRow2["ID"].ToString() + "\" data-title=\"" + dataRow2["Title"].ToString().Trim() + "\" data-model=\"" + dataRow2["OpenMode"].ToString() + "\" data-width=\"" + dataRow2["Width"].ToString() + "\" data-height=\"" + dataRow2["Height"].ToString() + "\" data-childs=\"" + (flag ? "1" : "0") + "\" data-url=\"" + getAddress(dataRow2, params2) + "\" data-parent=\"" + Guid.Empty.ToString() + "\" style=\"" + (str2.IsNullOrEmpty() ? "" : ("color:" + str2.Trim1() + ";")) + "\">");
					stringBuilder.Append("<div class=\"menulistdiv1\">");
					string text2 = dataRow2["Ico"].ToString();
					if (text2.IsNullOrEmpty())
					{
						text2 = dataRow2["AppIco"].ToString();
					}
					if (text2.IsNullOrEmpty())
					{
						stringBuilder.Append("<i class=\"fa fa-th-list\" style=\"margin-right:3px;vertical-align:middle\"></i>");
					}
					else if (text2.IsFontIco())
					{
						stringBuilder.Append("<i class=\"fa " + text2 + "\" style=\"margin-right:3px;vertical-align:middle\"></i>");
					}
					else
					{
						stringBuilder.Append("<img src=\"" + Config.BaseUrl + text2 + "\" style=\"vertical-align:middle\" alt=\"\"/>");
					}
					stringBuilder.Append("</div>");
					stringBuilder.Append("</div>");
				}
			}
			return stringBuilder.ToString();
		}

		public string GetUserMenuJsonString(Guid userID, string rootDir = "", bool showSource = false)
		{
			Menu menu = new Menu();
			new AppLibrary();
			DataTable allDataTable = menu.GetAllDataTable();
			if (allDataTable.Rows.Count == 0)
			{
				return "[]";
			}
			DataRow[] array = allDataTable.Select(string.Format("ParentID='{0}'", Guid.Empty.ToString()));
			if (array.Length == 0)
			{
				return "[]";
			}
			List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll();
			DataRow[] array2 = allDataTable.Select(string.Format("ParentID='{0}'", array[0]["ID"].ToString()));
			StringBuilder stringBuilder = new StringBuilder("", 1000);
			DataRow dataRow = array[0];
			string empty = string.Empty;
			stringBuilder.Append("{");
			stringBuilder.AppendFormat("\"id\":\"{0}\",", dataRow["ID"].ToString());
			stringBuilder.AppendFormat("\"title\":\"{0}\",", dataRow["Title"].ToString().Trim());
			stringBuilder.AppendFormat("\"ico\":\"{0}\",", dataRow["AppIco"].ToString());
			stringBuilder.AppendFormat("\"color\":\"{0}\",", dataRow["IcoColor"].ToString());
			stringBuilder.AppendFormat("\"link\":\"{0}\",", getAddress(dataRow).ToString(), empty);
			stringBuilder.AppendFormat("\"model\":\"{0}\",", dataRow["OpenMode"].ToString());
			stringBuilder.AppendFormat("\"width\":\"{0}\",", dataRow["Width"].ToString());
			stringBuilder.AppendFormat("\"height\":\"{0}\",", dataRow["Height"].ToString());
			stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (array2.Length != 0) ? "1" : "0");
			stringBuilder.AppendFormat("\"childs\":[");
			StringBuilder stringBuilder2 = new StringBuilder(array2.Length * 100);
			string source = string.Empty;
			if (!showSource)
			{
				List<RoadFlow.Data.Model.UserShortcut> allByUserID = new UserShortcut().GetAllByUserID(userID, true);
				if (allByUserID.Count > 0)
				{
					stringBuilder2.Append("{");
					stringBuilder2.AppendFormat("\"id\":\"{0}\",", Guid.NewGuid());
					stringBuilder2.AppendFormat("\"title\":\"{0}\",", "快捷菜单");
					stringBuilder2.AppendFormat("\"ico\":\"{0}\",", "");
					stringBuilder2.AppendFormat("\"color\":\"{0}\",", "");
					stringBuilder2.AppendFormat("\"link\":\"{0}\",", "");
					stringBuilder2.AppendFormat("\"model\":\"{0}\",", "");
					stringBuilder2.AppendFormat("\"width\":\"{0}\",", "");
					stringBuilder2.AppendFormat("\"height\":\"{0}\",", "");
					stringBuilder2.AppendFormat("\"hasChilds\":\"1\",");
					stringBuilder2.AppendFormat("\"childs\":[");
					StringBuilder stringBuilder3 = new StringBuilder();
					foreach (RoadFlow.Data.Model.UserShortcut item in allByUserID)
					{
						string @params = string.Empty;
						List<RoadFlow.Data.Model.MenuUser> list = all.FindAll(delegate(RoadFlow.Data.Model.MenuUser p)
						{
							if (p.MenuID == item.MenuID && p.SubPageID == Guid.Empty)
							{
								return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
							}
							return false;
						});
						if (list.Count > 0)
						{
							StringBuilder stringBuilder4 = new StringBuilder();
							foreach (IGrouping<string, RoadFlow.Data.Model.MenuUser> item2 in from p in list.FindAll((RoadFlow.Data.Model.MenuUser p) => !p.Params.IsNullOrEmpty())
							group p by p.Params)
							{
								stringBuilder4.Append(item2.Key.Trim1());
								stringBuilder4.Append("&");
							}
							@params = stringBuilder4.ToString().TrimEnd('&');
						}
						if (HasUse(item.MenuID, userID, all, out source, out @params, showSource))
						{
							DataRow[] array3 = allDataTable.Select(string.Format("ID='{0}'", item.MenuID.ToString()));
							if (array3.Length != 0)
							{
								DataRow dataRow2 = array3[0];
								DataRow[] array4 = allDataTable.Select("ParentID='" + dataRow2["ID"].ToString() + "'");
								stringBuilder3.Append("{");
								stringBuilder3.AppendFormat("\"id\":\"{0}\",", dataRow2["ID"].ToString());
								stringBuilder3.AppendFormat("\"title\":\"{0}\",", dataRow2["Title"].ToString().Trim1());
								stringBuilder3.AppendFormat("\"ico\":\"{0}\",", dataRow2["AppIco"].ToString());
								stringBuilder3.AppendFormat("\"color\":\"{0}\",", dataRow2["IcoColor"].ToString());
								stringBuilder3.AppendFormat("\"link\":\"{0}\",", getAddress(dataRow2, @params));
								stringBuilder3.AppendFormat("\"model\":\"{0}\",", dataRow2["OpenMode"].ToString());
								stringBuilder3.AppendFormat("\"width\":\"{0}\",", dataRow2["Width"].ToString());
								stringBuilder3.AppendFormat("\"height\":\"{0}\",", dataRow2["Height"].ToString());
								stringBuilder3.AppendFormat("\"hasChilds\":\"{0}\",", (array4.Length != 0) ? "1" : "0");
								stringBuilder3.AppendFormat("\"childs\":[]");
								stringBuilder3.Append("},");
							}
						}
					}
					stringBuilder2.Append((stringBuilder3.Length > 0) ? stringBuilder3.ToString().TrimEnd(',') : "");
					stringBuilder2.Append("]");
					stringBuilder2.Append("}");
					if (array2.Length != 0)
					{
						stringBuilder2.Append(",");
					}
				}
			}
			for (int i = 0; i < array2.Length; i++)
			{
				string params2 = string.Empty;
				DataRow dataRow3 = array2[i];
				if (HasUse(dataRow3["ID"].ToString().ToGuid(), userID, all, out source, out params2, showSource))
				{
					DataRow[] array5 = allDataTable.Select("ParentID='" + dataRow3["ID"].ToString() + "'");
					bool flag = false;
					DataRow[] array6 = array5;
					foreach (DataRow dataRow4 in array6)
					{
						if (HasUse(dataRow4["ID"].ToString().ToGuid(), userID, all, out source, out params2, showSource))
						{
							flag = true;
							break;
						}
					}
					stringBuilder2.Append("{");
					stringBuilder2.AppendFormat("\"id\":\"{0}\",", dataRow3["ID"].ToString());
					stringBuilder2.AppendFormat("\"title\":\"{0}{1}\",", dataRow3["Title"].ToString().Trim1(), showSource ? ("<span style='margin-left:4px;color:#666;'>[" + source + "]</span>") : "");
					stringBuilder2.AppendFormat("\"ico\":\"{0}\",", dataRow3["AppIco"].ToString());
					stringBuilder2.AppendFormat("\"color\":\"{0}\",", dataRow3["IcoColor"].ToString());
					stringBuilder2.AppendFormat("\"link\":\"{0}\",", getAddress(dataRow3, params2));
					stringBuilder2.AppendFormat("\"model\":\"{0}\",", dataRow3["OpenMode"].ToString());
					stringBuilder2.AppendFormat("\"width\":\"{0}\",", dataRow3["Width"].ToString());
					stringBuilder2.AppendFormat("\"height\":\"{0}\",", dataRow3["Height"].ToString());
					stringBuilder2.AppendFormat("\"hasChilds\":\"{0}\",", flag ? "1" : "0");
					stringBuilder2.AppendFormat("\"childs\":[");
					stringBuilder2.Append("]");
					stringBuilder2.Append("}");
					stringBuilder2.Append(",");
				}
			}
			stringBuilder.Append(stringBuilder2.ToString().TrimEnd(','));
			stringBuilder.Append("]");
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public string GetUserMenuRefreshJsonString(Guid userID, Guid refreshID, string rootDir = "", bool showSource = false)
		{
			DataTable allDataTable = GetAllDataTable();
			DataView defaultView = allDataTable.DefaultView;
			defaultView.RowFilter = string.Format("ParentID='{0}'", refreshID);
			defaultView.Sort = "Sort";
			DataTable dataTable = defaultView.ToTable();
			if (dataTable.Rows.Count == 0)
			{
				return "[]";
			}
			int count = dataTable.Rows.Count;
			StringBuilder stringBuilder = new StringBuilder("[", count * 100);
			List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll();
			string source = string.Empty;
			foreach (DataRow row in dataTable.Rows)
			{
				string @params = string.Empty;
				if (HasUse(row["ID"].ToString().ToGuid(), userID, all, out source, out @params, showSource))
				{
					DataRow[] array = allDataTable.Select(string.Format("ParentID='{0}'", row["id"].ToString()));
					bool flag = false;
					DataRow[] array2 = array;
					foreach (DataRow dataRow2 in array2)
					{
						if (HasUse(dataRow2["ID"].ToString().ToGuid(), userID, all, out source, out @params, showSource))
						{
							flag = true;
							break;
						}
					}
					stringBuilder.Append("{");
					stringBuilder.AppendFormat("\"id\":\"{0}\",", row["ID"].ToString());
					stringBuilder.AppendFormat("\"title\":\"{0}{1}\",", row["Title"].ToString().Trim1(), showSource ? ("<span style='margin-left:4px;color:#666;'>[" + source + "]</span>") : "");
					stringBuilder.AppendFormat("\"ico\":\"{0}\",", row["AppIco"].ToString());
					stringBuilder.AppendFormat("\"color\":\"{0}\",", row["IcoColor"].ToString());
					stringBuilder.AppendFormat("\"link\":\"{0}\",", getAddress(row, @params));
					stringBuilder.AppendFormat("\"model\":\"{0}\",", row["OpenMode"].ToString());
					stringBuilder.AppendFormat("\"width\":\"{0}\",", row["Width"].ToString());
					stringBuilder.AppendFormat("\"height\":\"{0}\",", row["Height"].ToString());
					stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? "1" : "0");
					stringBuilder.AppendFormat("\"childs\":[");
					stringBuilder.Append("]");
					stringBuilder.Append("}");
					stringBuilder.Append(",");
				}
			}
			return stringBuilder.ToString().TrimEnd(',') + "]";
		}

		public bool HasUse(Guid menuID, Guid userID, List<RoadFlow.Data.Model.MenuUser> menuusers, out string source, out string params1, bool showSource = false)
		{
			source = string.Empty;
			params1 = string.Empty;
			List<RoadFlow.Data.Model.MenuUser> list = menuusers.FindAll(delegate(RoadFlow.Data.Model.MenuUser p)
			{
				if (p.MenuID == menuID && p.SubPageID == Guid.Empty)
				{
					return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
				}
				return false;
			});
			if (list.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (RoadFlow.Data.Model.MenuUser item in list)
				{
					stringBuilder.Append(item.Organizes);
					stringBuilder.Append(",");
					if (!item.Params.IsNullOrEmpty())
					{
						params1 = item.Params;
					}
				}
				Organize organize = new Organize();
				source = organize.GetNames(stringBuilder.ToString().TrimEnd(','));
				StringBuilder stringBuilder2 = new StringBuilder();
				foreach (IGrouping<string, RoadFlow.Data.Model.MenuUser> item2 in from p in list.FindAll((RoadFlow.Data.Model.MenuUser p) => !p.Params.IsNullOrEmpty())
				group p by p.Params)
				{
					stringBuilder2.Append(item2.Key.Trim1());
					stringBuilder2.Append("&");
				}
				params1 = stringBuilder2.ToString().TrimEnd('&');
				return true;
			}
			return false;
		}

		public string GetMenuTreeTableHtml(string orgID, Guid? userId = default(Guid?))
		{
			DataTable allDataTable = new Menu().GetAllDataTable();
			List<RoadFlow.Data.Model.MenuUser> all = new MenuUser().GetAll();
			StringBuilder stringBuilder = new StringBuilder();
			getMenuTreeTableHtml(stringBuilder, allDataTable, Guid.Empty, all, orgID, userId);
			return stringBuilder.ToString();
		}

		private void getMenuTreeTableHtml(StringBuilder sb, DataTable appDt, Guid parentID, List<RoadFlow.Data.Model.MenuUser> menuUsers, string orgID, Guid? userId = default(Guid?))
		{
			DataRow[] array = appDt.Select("ParentID='" + parentID.ToString() + "'");
			DataRow[] array2 = array;
			foreach (DataRow dr in array2)
			{
				string source;
				string @params;
				if (!userId.HasValue || !userId.HasValue || userId.Value.IsEmptyGuid() || HasUse(dr["ID"].ToString().ToGuid(), userId.Value, menuUsers, out source, out @params))
				{
					RoadFlow.Data.Model.MenuUser menuUser = menuUsers.Find(delegate(RoadFlow.Data.Model.MenuUser p)
					{
						if (p.MenuID == dr["ID"].ToString().ToGuid() && p.SubPageID.IsEmptyGuid())
						{
							return p.Organizes.Contains(orgID, StringComparison.CurrentCultureIgnoreCase);
						}
						return false;
					});
					string text = (menuUser != null) ? " checked=\"checked\"" : "";
					sb.Append("<tr id=\"" + dr["ID"] + "\" data-pid=\"" + dr["ParentID"] + "\">");
					sb.Append("<td>" + dr["Title"] + "</td>");
					if (!dr["Ico"].ToString().IsNullOrEmpty())
					{
						sb.Append("<td><input type=\"hidden\" name=\"apptype\" value=\"0\"/>" + (dr["Ico"].ToString().IsFontIco() ? ("<i class=\"fa " + dr["Ico"].ToString() + "\" style=\"font-size:14px;\"></i>") : ("<img src=\"" + dr["Ico"] + "\" style=\"vertical-align:middle;\"/>")) + "</td>");
					}
					else
					{
						sb.Append("<td><input type=\"hidden\" name=\"apptype\" value=\"0\"/>" + (dr["AppIco"].ToString().IsNullOrEmpty() ? "" : (dr["AppIco"].ToString().IsFontIco() ? ("<i class=\"fa " + dr["AppIco"].ToString() + "\" style=\"font-size:14px;\"></i>") : ("<img src=\"" + dr["AppIco"] + "\" style=\"vertical-align:middle;\"/>"))) + "</td>");
					}
					sb.Append("<td style=\"text-align:center\"><input type=\"checkbox\" " + text + " onclick=\"appboxclick(this);\" name=\"menuid\" value=\"" + dr["ID"] + "\"/></td>");
					sb.Append("<td>");
					bool flag = dr["AppLibraryID"].ToString().IsGuid();
					if (flag)
					{
						foreach (RoadFlow.Data.Model.AppLibraryButtons1 item in from p in new AppLibraryButtons1().GetAllByAppID(dr["AppLibraryID"].ToString().ToGuid())
						orderby p.ShowType, p.Sort
						select p)
						{
							text = ((menuUser != null && menuUser.Buttons.Contains(item.ID.ToString(), StringComparison.CurrentCultureIgnoreCase)) ? " checked=\"checked\"" : "");
							sb.Append("<input type=\"checkbox\" " + text + " onclick=\"buttonboxclick(this);\" style=\"vertical-align:middle;\" id=\"button_" + dr["ID"] + "_" + item.ID + "\" name=\"button_" + dr["ID"] + "\" value=\"" + item.ID + "\"/>");
							sb.Append("<label style=\"vertical-align:middle;\" for=\"button_" + dr["ID"] + "_" + item.ID + "\">" + item.Name + "</label>");
						}
					}
					sb.Append("</td>");
					if (flag)
					{
						sb.Append("<td><input type=\"text\" class=\"mytext\" style=\"width:95%\" value=\"" + ((menuUser != null) ? menuUser.Params : "") + "\" name=\"params_" + dr["id"] + "\"/></td>");
					}
					else
					{
						sb.Append("<td>&nbsp;</td>");
					}
					sb.Append("</tr>");
					if (flag)
					{
						foreach (RoadFlow.Data.Model.AppLibrarySubPages item2 in from p in new AppLibrarySubPages().GetAllByAppID(dr["AppLibraryID"].ToString().ToGuid())
						orderby p.Sort
						select p)
						{
							menuUser = menuUsers.Find(delegate(RoadFlow.Data.Model.MenuUser p)
							{
								if (p.MenuID == dr["ID"].ToString().ToGuid() && p.SubPageID == item2.ID)
								{
									return p.Organizes.Contains(orgID, StringComparison.CurrentCultureIgnoreCase);
								}
								return false;
							});
							text = ((menuUser != null) ? " checked=\"checked\"" : "");
							sb.Append("<tr id=\"" + item2.ID + "\" data-pid=\"" + dr["ID"] + "\">");
							sb.Append("<td>" + item2.Name + "</td>");
							sb.Append("<td><input type=\"hidden\" name=\"apptype\" value=\"1\"/></td>");
							sb.Append("<td style=\"text-align:center\"><input type=\"checkbox\" " + text + " onclick=\"appboxclick(this);\" name=\"subpage_" + dr["id"] + "\" value=\"" + item2.ID + "\"/></td>");
							sb.Append("<td>");
							foreach (RoadFlow.Data.Model.AppLibraryButtons1 item3 in new AppLibraryButtons1().GetAllByAppID(item2.ID).OrderBy((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ShowType).ThenBy((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.Sort))
							{
								text = ((menuUser != null && menuUser.Buttons.Contains(item3.ID.ToString(), StringComparison.CurrentCultureIgnoreCase)) ? " checked=\"checked\"" : "");
								sb.Append("<input type=\"checkbox\" " + text + " onclick=\"buttonboxclick(this);\" style=\"vertical-align:middle;\" id=\"button_" + item2.ID + "_" + item3.ID + "\" name=\"button_" + dr["id"] + "_" + item2.ID + "\" value=\"" + item3.ID + "\"/>");
								sb.Append("<label style=\"vertical-align:middle;\" for=\"button_" + item2.ID + "_" + item3.ID + "\">" + item3.Name + "</label>");
							}
							sb.Append("</td>");
							sb.Append("<td>&nbsp;</td>");
							sb.Append("</tr>");
						}
					}
					getMenuTreeTableHtml(sb, appDt, dr["ID"].ToString().ToGuid(), menuUsers, orgID, userId);
				}
			}
		}

		public List<RoadFlow.Data.Model.Menu> GetAllByApplibaryID(Guid applibaryID)
		{
			return dataMenu.GetAllByApplibaryID(applibaryID);
		}
	}
}
