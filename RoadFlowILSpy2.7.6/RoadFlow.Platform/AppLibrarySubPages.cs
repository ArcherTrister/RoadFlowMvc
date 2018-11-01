using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class AppLibrarySubPages
	{
		private static readonly string cachekey = 0.ToString() + "_AppLibrarySubPages";

		private IAppLibrarySubPages dataAppLibrarySubPages;

		public AppLibrarySubPages()
		{
			dataAppLibrarySubPages = Factory.GetAppLibrarySubPages();
		}

		public int Add(RoadFlow.Data.Model.AppLibrarySubPages model)
		{
			return dataAppLibrarySubPages.Add(model);
		}

		public int Update(RoadFlow.Data.Model.AppLibrarySubPages model)
		{
			return dataAppLibrarySubPages.Update(model);
		}

		public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAll(bool cache = true)
		{
			if (!cache)
			{
				return dataAppLibrarySubPages.GetAll();
			}
			object obj = Opation.Get(cachekey);
			if (obj == null || !(obj is List<RoadFlow.Data.Model.AppLibrarySubPages>))
			{
				List<RoadFlow.Data.Model.AppLibrarySubPages> all = dataAppLibrarySubPages.GetAll();
				Opation.Set(cachekey, all);
				return all;
			}
			return (List<RoadFlow.Data.Model.AppLibrarySubPages>)obj;
		}

		public RoadFlow.Data.Model.AppLibrarySubPages Get(Guid id)
		{
			return dataAppLibrarySubPages.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataAppLibrarySubPages.Delete(id);
		}

		public long GetCount()
		{
			return dataAppLibrarySubPages.GetCount();
		}

		public int DeleteByAppID(Guid id)
		{
			return dataAppLibrarySubPages.DeleteByAppID(id);
		}

		public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAllByAppID(Guid id)
		{
			return dataAppLibrarySubPages.GetAllByAppID(id);
		}

		public void ClearCache()
		{
			Opation.Remove(cachekey);
		}
	}
}
