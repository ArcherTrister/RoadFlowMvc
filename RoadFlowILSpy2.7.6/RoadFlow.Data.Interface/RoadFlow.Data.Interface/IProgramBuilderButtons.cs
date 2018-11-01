using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IProgramBuilderButtons
	{
		int Add(ProgramBuilderButtons model);

		int Update(ProgramBuilderButtons model);

		List<ProgramBuilderButtons> GetAll();

		ProgramBuilderButtons Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<ProgramBuilderButtons> GetAll(Guid id);
	}
}
