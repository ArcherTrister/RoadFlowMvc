using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class ProgramBuilderButtons
	{
		private IProgramBuilderButtons dataProgramBuilderButtons;

		public ProgramBuilderButtons()
		{
			dataProgramBuilderButtons = Factory.GetProgramBuilderButtons();
		}

		public int Add(RoadFlow.Data.Model.ProgramBuilderButtons model)
		{
			return dataProgramBuilderButtons.Add(model);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderButtons model)
		{
			return dataProgramBuilderButtons.Update(model);
		}

		public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll()
		{
			return dataProgramBuilderButtons.GetAll();
		}

		public RoadFlow.Data.Model.ProgramBuilderButtons Get(Guid id)
		{
			return dataProgramBuilderButtons.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataProgramBuilderButtons.Delete(id);
		}

		public long GetCount()
		{
			return dataProgramBuilderButtons.GetCount();
		}

		public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll(Guid programID)
		{
			return dataProgramBuilderButtons.GetAll(programID);
		}
	}
}
