using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IAppLibrary
	{
		int Add(AppLibrary model);

		int Update(AppLibrary model);

		List<AppLibrary> GetAll();

		AppLibrary Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<AppLibrary> GetPagerData(out string pager, string query = "", string order = "Type,Title", int size = 15, int number = 1, string title = "", string type = "", string address = "");

		List<AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "");

		List<AppLibrary> GetAllByType(string type);

		int Delete(string[] idArray);

		AppLibrary GetByCode(string code);
	}
}
