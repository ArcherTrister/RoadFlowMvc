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
	public class HomeItems
	{
		private Dictionary<int, string> types = new Dictionary<int, string>();

		private Dictionary<int, string> dstypes = new Dictionary<int, string>();

		private IHomeItems dataHomeItems;

		private string cacheKey = string.Empty;

		public HomeItems()
		{
			cacheKey = 20.ToString();
			dataHomeItems = Factory.GetHomeItems();
			types.Add(0, "顶部统计");
			types.Add(1, "左边列表");
			types.Add(2, "右边列表");
			dstypes.Add(0, "SQL语句");
			dstypes.Add(1, "C#方法");
			dstypes.Add(2, "URL地址");
		}

		public int Add(RoadFlow.Data.Model.HomeItems model)
		{
			return dataHomeItems.Add(model);
		}

		public int Update(RoadFlow.Data.Model.HomeItems model)
		{
			return dataHomeItems.Update(model);
		}

		public List<RoadFlow.Data.Model.HomeItems> GetAll()
		{
			return dataHomeItems.GetAll();
		}

		public RoadFlow.Data.Model.HomeItems Get(Guid id)
		{
			return dataHomeItems.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataHomeItems.Delete(id);
		}

		public long GetCount()
		{
			return dataHomeItems.GetCount();
		}

		public List<RoadFlow.Data.Model.HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "")
		{
			return dataHomeItems.GetList(out pager, query, name, title, type);
		}

		public List<RoadFlow.Data.Model.HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "")
		{
			return dataHomeItems.GetList(out count, size, number, name, title, type, order);
		}

		public string getTypeOptions(string value = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, string> type in types)
			{
				stringBuilder.Append("<option value=\"" + type.Key.ToString() + "\"" + (type.Key.ToString().Equals(value) ? " selected=\"selected\"" : "") + ">" + type.Value + "</option>");
			}
			return stringBuilder.ToString();
		}

		public string getDataSourceOptions(string value = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, string> dstype in dstypes)
			{
				stringBuilder.Append("<option value=\"" + dstype.Key.ToString() + "\"" + (dstype.Key.ToString().Equals(value) ? " selected=\"selected\"" : "") + ">" + dstype.Value + "</option>");
			}
			return stringBuilder.ToString();
		}

		public string GetTypeTitle(int type)
		{
			if (!types.ContainsKey(type))
			{
				return "";
			}
			return types[type];
		}

		public string GetDataSourceTitle(int type)
		{
			if (!dstypes.ContainsKey(type))
			{
				return "";
			}
			return dstypes[type];
		}

		public string GetDataSourceString(RoadFlow.Data.Model.HomeItems item)
		{
			if (item != null)
			{
				switch (item.DataSourceType)
				{
				case 0:
					if (item.DBConnID.HasValue)
					{
						return getSqlString(item.DataSource, item.Type, item.DBConnID.Value);
					}
					return "";
				case 1:
					return GetCsharpMethodString(item.DataSource);
				case 2:
					return GetUrlString(item.DataSource);
				default:
					return "";
				}
			}
			return "";
		}

		private string getSqlString(string sql, int type, Guid dbconnID)
		{
			if (type == 0)
			{
				return new DBConnection().GetFieldValue(dbconnID, Wildcard.FilterWildcard(sql));
			}
			if ((uint)(type - 1) <= 1u)
			{
				DataTable dataTable = new DBConnection().GetDataTable(dbconnID, Wildcard.FilterWildcard(sql));
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" class=\"hometable\"><thead><tr>");
				foreach (DataColumn column in dataTable.Columns)
				{
					stringBuilder.Append("<th>" + column.ColumnName + "</th>");
				}
				stringBuilder.Append("</tr></thead><tbody>");
				foreach (DataRow row in dataTable.Rows)
				{
					stringBuilder.Append("<tr>");
					foreach (DataColumn column2 in dataTable.Columns)
					{
						stringBuilder.Append("<td>" + row[column2.ColumnName].ToString() + "</td>");
					}
					stringBuilder.Append("</tr>");
				}
				stringBuilder.Append("</tbody></table>");
				return stringBuilder.ToString();
			}
			return "";
		}

		private string GetCsharpMethodString(string method, object param = null)
		{
			object obj = Tools.ExecuteCsharpMethod(method, param);
			if (obj != null)
			{
				return obj.ToString();
			}
			return "";
		}

		public string GetUrlString(string url)
		{
			return HttpHelper.SendGet(url);
		}

		public List<RoadFlow.Data.Model.HomeItems> GetAllByUserID(Guid userID)
		{
			object obj = Opation.Get(cacheKey);
			List<RoadFlow.Data.Model.HomeItems> list = new List<RoadFlow.Data.Model.HomeItems>();
			if (obj != null && obj is List<RoadFlow.Data.Model.HomeItems>)
			{
				list = (List<RoadFlow.Data.Model.HomeItems>)obj;
			}
			else
			{
				Organize organize = new Organize();
				list = GetAll();
				foreach (RoadFlow.Data.Model.HomeItems item in list)
				{
					item.UseUsers = organize.GetAllUsersIdString(item.UseOrganizes);
				}
				Opation.Set(cacheKey, list);
			}
			return (from p in list.FindAll((RoadFlow.Data.Model.HomeItems p) => p.UseUsers.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase))
			orderby p.Type, p.Sort
			select p).ToList();
		}

		public int GetMaxSort(int type)
		{
			return dataHomeItems.GetMaxSort(type);
		}

		public void ClearCache()
		{
			Opation.Remove(cacheKey);
		}
	}
}
