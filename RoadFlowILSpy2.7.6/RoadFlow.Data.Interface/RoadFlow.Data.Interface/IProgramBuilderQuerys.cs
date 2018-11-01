using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IProgramBuilderQuerys
	{
		int Add(ProgramBuilderQuerys model);

		int Update(ProgramBuilderQuerys model);

		List<ProgramBuilderQuerys> GetAll();

		ProgramBuilderQuerys Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<ProgramBuilderQuerys> GetAll(Guid programID);

		int DeleteByProgramID(Guid id);
	}
}
