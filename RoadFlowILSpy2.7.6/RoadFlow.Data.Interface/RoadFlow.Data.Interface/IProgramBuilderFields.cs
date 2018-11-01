using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IProgramBuilderFields
	{
		int Add(ProgramBuilderFields model);

		int Update(ProgramBuilderFields model);

		List<ProgramBuilderFields> GetAll();

		ProgramBuilderFields Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		int DeleteByProgramID(Guid id);

		List<ProgramBuilderFields> GetAll(Guid programID);
	}
}
