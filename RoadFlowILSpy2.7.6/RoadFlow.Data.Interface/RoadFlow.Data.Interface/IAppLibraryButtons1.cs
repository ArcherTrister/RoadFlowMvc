using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IAppLibraryButtons1
	{
		int Add(AppLibraryButtons1 model);

		int Update(AppLibraryButtons1 model);

		List<AppLibraryButtons1> GetAll();

		AppLibraryButtons1 Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		int DeleteByAppID(Guid id);

		List<AppLibraryButtons1> GetAllByAppID(Guid id);
	}
}
