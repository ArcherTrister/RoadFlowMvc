using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
	public class AppLibrary
	{
		private string cacheKey = 1.ToString();

		private IAppLibrary dataAppLibrary;

		public AppLibrary()
		{
			dataAppLibrary = Factory.GetAppLibrary();
		}

		public int Add(RoadFlow.Data.Model.AppLibrary model)
		{
			return dataAppLibrary.Add(model);
		}

		public int Update(RoadFlow.Data.Model.AppLibrary model)
		{
			return dataAppLibrary.Update(model);
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetAll(bool fromCache = false)
		{
			if (!fromCache)
			{
				return dataAppLibrary.GetAll();
			}
			object obj = Opation.Get(cacheKey);
			if (obj != null && obj is List<RoadFlow.Data.Model.AppLibrary>)
			{
				return (List<RoadFlow.Data.Model.AppLibrary>)obj;
			}
			List<RoadFlow.Data.Model.AppLibrary> all = dataAppLibrary.GetAll();
			Opation.Set(cacheKey, all);
			return all;
		}

		public RoadFlow.Data.Model.AppLibrary Get(Guid id, bool fromCache = false)
		{
			if (!fromCache)
			{
				return dataAppLibrary.Get(id);
			}
			RoadFlow.Data.Model.AppLibrary appLibrary = GetAll(true).Find((RoadFlow.Data.Model.AppLibrary p) => p.ID == id);
			if (appLibrary != null)
			{
				return appLibrary;
			}
			return dataAppLibrary.Get(id);
		}

		public void ClearCache()
		{
			Opation.Remove(cacheKey);
		}

		public int Delete(Guid id)
		{
			return dataAppLibrary.Delete(id);
		}

		public long GetCount()
		{
			return dataAppLibrary.GetCount();
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out string pager, string query = "", string title = "", string type = "", string address = "")
		{
			return dataAppLibrary.GetPagerData(out pager, query, "Type,Title", Tools.GetPageSize(), Tools.GetPageNumber(), title, type, address);
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "")
		{
			return dataAppLibrary.GetPagerData(out count, size, number, title, type, address, order);
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetAllByType(Guid type)
		{
			if (type.IsEmptyGuid())
			{
				return new List<RoadFlow.Data.Model.AppLibrary>();
			}
			return (from p in dataAppLibrary.GetAllByType(GetAllChildsIDString(type))
			orderby p.Title
			select p).ToList();
		}

		public int Delete(string[] idArray)
		{
			return dataAppLibrary.Delete(idArray);
		}

		public int Delete(string idstring)
		{
			if (!idstring.IsNullOrEmpty())
			{
				return dataAppLibrary.Delete(idstring.Split(','));
			}
			return 0;
		}

		public string GetTypeOptions(string value = "")
		{
			return new Dictionary().GetOptionsByCode("AppLibraryTypes", Dictionary.OptionValueField.ID, value);
		}

		public string GetAllChildsIDString(Guid id, bool isSelf = true)
		{
			return new Dictionary().GetAllChildsIDString(id);
		}

		public string GetAppsOptions(Guid type, string value = "")
		{
			if (type.IsEmptyGuid())
			{
				return "";
			}
			List<RoadFlow.Data.Model.AppLibrary> allByType = GetAllByType(type);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.AppLibrary item in allByType)
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item.ID, (string.Compare(item.ID.ToString(), value, true) == 0) ? "selected=\"selected\"" : "", item.Title);
			}
			return stringBuilder.ToString();
		}

		public string GetTypeByID(Guid id)
		{
			RoadFlow.Data.Model.AppLibrary appLibrary = Get(id);
			if (appLibrary != null)
			{
				return appLibrary.Type.ToString();
			}
			return "";
		}

		public RoadFlow.Data.Model.AppLibrary GetByCode(string code, bool formCache = true)
		{
			if (code.IsNullOrEmpty())
			{
				return null;
			}
			if (formCache)
			{
				RoadFlow.Data.Model.AppLibrary appLibrary = GetAll(true).Find(delegate(RoadFlow.Data.Model.AppLibrary p)
				{
					if (!p.Code.IsNullOrEmpty())
					{
						return p.Code.Equals(code.Trim1(), StringComparison.CurrentCultureIgnoreCase);
					}
					return false;
				});
				if (appLibrary == null)
				{
					return dataAppLibrary.GetByCode(code.Trim1());
				}
				return appLibrary;
			}
			return dataAppLibrary.GetByCode(code.Trim1());
		}

		public string GetFlowRunAddress(RoadFlow.Data.Model.AppLibrary app, string query = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (app.Params.IsNullOrEmpty())
			{
				if (!app.Address.Contains("?"))
				{
					stringBuilder.Append(app.Address);
					stringBuilder.Append("?1=1");
				}
			}
			else if (app.Address.Contains("?"))
			{
				stringBuilder.Append(app.Address);
				stringBuilder.Append("&");
				stringBuilder.Append(app.Params.TrimStart('?').TrimStart('&'));
			}
			else
			{
				stringBuilder.Append(app.Address);
				stringBuilder.Append("?");
				stringBuilder.Append(app.Params.TrimStart('?').TrimStart('&'));
			}
			if (!query.IsNullOrEmpty())
			{
				stringBuilder.Append("&");
				stringBuilder.Append(query.TrimStart('?').TrimStart('&'));
			}
			return stringBuilder.ToString();
		}
	}
}
