using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class AppLibraryButtons1
	{
		private static readonly string cachekey = 0.ToString() + "_AppLibraryButtons1";

		private IAppLibraryButtons1 dataAppLibraryButtons1;

		public AppLibraryButtons1()
		{
			dataAppLibraryButtons1 = Factory.GetAppLibraryButtons1();
		}

		public int Add(RoadFlow.Data.Model.AppLibraryButtons1 model)
		{
			return dataAppLibraryButtons1.Add(model);
		}

		public int Update(RoadFlow.Data.Model.AppLibraryButtons1 model)
		{
			return dataAppLibraryButtons1.Update(model);
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAll(bool cache = true)
		{
			if (!cache)
			{
				return dataAppLibraryButtons1.GetAll();
			}
			object obj = Opation.Get(cachekey);
			if (obj == null || !(obj is List<RoadFlow.Data.Model.AppLibraryButtons1>))
			{
				List<RoadFlow.Data.Model.AppLibraryButtons1> all = dataAppLibraryButtons1.GetAll();
				Opation.Set(cachekey, all);
				return all;
			}
			return (List<RoadFlow.Data.Model.AppLibraryButtons1>)obj;
		}

		public RoadFlow.Data.Model.AppLibraryButtons1 Get(Guid id, bool cache = false)
		{
			if (!cache)
			{
				return dataAppLibraryButtons1.Get(id);
			}
			return GetAll().Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == id);
		}

		public int Delete(Guid id)
		{
			return dataAppLibraryButtons1.Delete(id);
		}

		public long GetCount()
		{
			return dataAppLibraryButtons1.GetCount();
		}

		public int DeleteByAppID(Guid id)
		{
			return dataAppLibraryButtons1.DeleteByAppID(id);
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAllByAppID(Guid id)
		{
			return dataAppLibraryButtons1.GetAllByAppID(id);
		}

		public void ClearCache()
		{
			Opation.Remove(cachekey);
		}
	}
}
