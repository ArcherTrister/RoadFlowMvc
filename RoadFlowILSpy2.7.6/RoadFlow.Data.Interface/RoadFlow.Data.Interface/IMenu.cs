using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
	public interface IMenu
	{
		int Add(Menu model);

		int Update(Menu model);

		List<Menu> GetAll();

		Menu Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		DataTable GetAllDataTable();

		List<Menu> GetChild(Guid id);

		bool HasChild(Guid id);

		int UpdateSort(Guid id, int sort);

		int GetMaxSort(Guid id);

		List<Menu> GetAllByApplibaryID(Guid applibaryID);
	}
}
