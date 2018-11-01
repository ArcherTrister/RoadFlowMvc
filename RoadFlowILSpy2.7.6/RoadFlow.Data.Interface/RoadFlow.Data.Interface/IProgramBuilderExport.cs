using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IProgramBuilderExport
	{
		int Add(ProgramBuilderExport model);

		int Update(ProgramBuilderExport model);

		List<ProgramBuilderExport> GetAll();

		ProgramBuilderExport Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<ProgramBuilderExport> GetAll(Guid programID);
	}
}
