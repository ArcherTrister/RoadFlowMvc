using System;

namespace RoadFlow.Cache.Interface
{
	public interface ICache
	{
		bool Insert(string key, object obj);

		bool Insert(string key, object obj, DateTime expiry);

		object Get(string key);

		bool Remove(string key);

		void RemoveAll();
	}
}
