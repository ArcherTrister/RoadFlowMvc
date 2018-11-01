using RoadFlow.Cache.Interface;
using System;
using System.Web;
using System.Web.Caching;

namespace RoadFlow.Cache.InProc
{
	public class Cache : ICache
	{
		private static readonly object lockobj = new object();

		private static System.Web.Caching.Cache _cache;

		private static System.Web.Caching.Cache cache
		{
			get
			{
				if (_cache != null)
				{
					return _cache;
				}
				if (HttpContext.Current != null)
				{
					_cache = HttpContext.Current.Cache;
					return _cache;
				}
				return null;
			}
		}

		public bool Insert(string key, object obj)
		{
			if (obj == null || cache == null)
			{
				return false;
			}
			lock (lockobj)
			{
				cache.Insert(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
			}
			return true;
		}

		public bool Insert(string key, object obj, DateTime expiry)
		{
			if (obj == null || cache == null)
			{
				return false;
			}
			lock (lockobj)
			{
				cache.Insert(key, obj, null, expiry, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
			}
			return true;
		}

		public object Get(string key)
		{
			if (cache == null)
			{
				return null;
			}
			return cache.Get(key);
		}

		public bool Remove(string key)
		{
			if (cache == null)
			{
				return false;
			}
			lock (lockobj)
			{
				cache.Remove(key);
			}
			return true;
		}

		public void RemoveAll()
		{
			for (int i = 0; i < cache.Count; i++)
			{
			}
		}
	}
}
