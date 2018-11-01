using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IProgramBuilder
	{
		int Add(ProgramBuilder model);

		int Update(ProgramBuilder model);

		List<ProgramBuilder> GetAll();

		ProgramBuilder Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "");
	}
}
