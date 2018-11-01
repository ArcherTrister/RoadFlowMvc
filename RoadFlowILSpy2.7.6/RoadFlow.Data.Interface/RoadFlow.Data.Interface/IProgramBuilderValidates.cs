using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IProgramBuilderValidates
	{
		int Add(ProgramBuilderValidates model);

		int Update(ProgramBuilderValidates model);

		List<ProgramBuilderValidates> GetAll();

		ProgramBuilderValidates Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<ProgramBuilderValidates> GetAll(Guid programID);

		int DeleteByProgramID(Guid id);
	}
}
