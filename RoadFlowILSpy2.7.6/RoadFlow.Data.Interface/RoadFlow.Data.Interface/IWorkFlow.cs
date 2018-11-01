using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkFlow
	{
		int Add(WorkFlow model);

		int Update(WorkFlow model);

		List<WorkFlow> GetAll();

		WorkFlow Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<string> GetAllTypes();

		Dictionary<Guid, string> GetAllIDAndName();

		List<WorkFlow> GetByTypes(string typeString);

		List<WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15);

		List<WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "");
	}
}
