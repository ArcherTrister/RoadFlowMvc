using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IAppLibraryButtons
	{
		int Add(AppLibraryButtons model);

		int Update(AppLibraryButtons model);

		List<AppLibraryButtons> GetAll();

		AppLibraryButtons Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<AppLibraryButtons> GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "");

		List<AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "");

		int GetMaxSort();
	}
}
