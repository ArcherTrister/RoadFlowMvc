using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IAppLibrarySubPages
	{
		int Add(AppLibrarySubPages model);

		int Update(AppLibrarySubPages model);

		List<AppLibrarySubPages> GetAll();

		AppLibrarySubPages Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		int DeleteByAppID(Guid id);

		List<AppLibrarySubPages> GetAllByAppID(Guid id);
	}
}
