using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RoadFlow.Platform
{
	public class UserShortcut
	{
		private IUserShortcut dataUserShortcut;

		private string cacheKey = 21.ToString();

		public UserShortcut()
		{
			dataUserShortcut = Factory.GetUserShortcut();
		}

		public int Add(RoadFlow.Data.Model.UserShortcut model)
		{
			return dataUserShortcut.Add(model);
		}

		public int Update(RoadFlow.Data.Model.UserShortcut model)
		{
			return dataUserShortcut.Update(model);
		}

		public List<RoadFlow.Data.Model.UserShortcut> GetAll(bool fromCache = false)
		{
			if (!fromCache)
			{
				return dataUserShortcut.GetAll();
			}
			object obj = Opation.Get(cacheKey);
			if (obj != null && obj is List<RoadFlow.Data.Model.UserShortcut>)
			{
				return (List<RoadFlow.Data.Model.UserShortcut>)obj;
			}
			List<RoadFlow.Data.Model.UserShortcut> all = dataUserShortcut.GetAll();
			Opation.Set(cacheKey, all);
			return all;
		}

		public RoadFlow.Data.Model.UserShortcut Get(Guid id)
		{
			return dataUserShortcut.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataUserShortcut.Delete(id);
		}

		public long GetCount()
		{
			return dataUserShortcut.GetCount();
		}

		public int DeleteByUserID(Guid userID)
		{
			return dataUserShortcut.DeleteByUserID(userID);
		}

		public List<RoadFlow.Data.Model.UserShortcut> GetAllByUserID(Guid userID, bool fromCache = false)
		{
			if (!fromCache)
			{
				return dataUserShortcut.GetAllByUserID(userID);
			}
			return (from p in GetAll(true).FindAll((RoadFlow.Data.Model.UserShortcut p) => p.UserID == userID)
			orderby p.Sort
			select p).ToList();
		}

		public DataTable GetDataTableByUserID(Guid userID)
		{
			return dataUserShortcut.GetDataTableByUserID(userID);
		}

		public void ClearCache()
		{
			Opation.Remove(cacheKey);
		}

		public int DeleteByMenuID(Guid menuID)
		{
			return dataUserShortcut.DeleteByMenuID(menuID);
		}
	}
}
