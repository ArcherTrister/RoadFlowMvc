using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IHomeItems
	{
		int Add(HomeItems model);

		int Update(HomeItems model);

		List<HomeItems> GetAll();

		HomeItems Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "");

		List<HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "");

		int GetMaxSort(int type);
	}
}
