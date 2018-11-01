using RoadFlow.Cache.Factory;
using System;

namespace RoadFlow.Cache.IO
{
	public class Opation
	{
		public static bool Insert(string key, object obj)
		{
			return RoadFlow.Cache.Factory.Cache.CreateInstance().Insert(key, obj);
		}

		public static bool Set(string key, object obj)
		{
			return Insert(key, obj);
		}

		public static bool Insert(string key, object obj, DateTime expiry)
		{
			return RoadFlow.Cache.Factory.Cache.CreateInstance().Insert(key, obj, expiry);
		}

		public static bool Set(string key, object obj, DateTime expiry)
		{
			return Insert(key, obj, expiry);
		}

		public static object Get(string key)
		{
			try
			{
				return RoadFlow.Cache.Factory.Cache.CreateInstance().Get(key);
			}
			catch
			{
				return null;
			}
		}

		public static bool Remove(string key)
		{
			return RoadFlow.Cache.Factory.Cache.CreateInstance().Remove(key);
		}

		public static void RemoveAll()
		{
			RoadFlow.Cache.Factory.Cache.CreateInstance().RemoveAll();
		}
	}
}
