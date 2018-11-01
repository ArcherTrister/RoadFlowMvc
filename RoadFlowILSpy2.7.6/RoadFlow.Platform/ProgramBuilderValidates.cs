using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class ProgramBuilderValidates
	{
		private IProgramBuilderValidates dataProgramBuilderValidates;

		public ProgramBuilderValidates()
		{
			dataProgramBuilderValidates = Factory.GetProgramBuilderValidates();
		}

		public int Add(RoadFlow.Data.Model.ProgramBuilderValidates model)
		{
			return dataProgramBuilderValidates.Add(model);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderValidates model)
		{
			return dataProgramBuilderValidates.Update(model);
		}

		public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll()
		{
			return dataProgramBuilderValidates.GetAll();
		}

		public RoadFlow.Data.Model.ProgramBuilderValidates Get(Guid id)
		{
			return dataProgramBuilderValidates.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataProgramBuilderValidates.Delete(id);
		}

		public long GetCount()
		{
			return dataProgramBuilderValidates.GetCount();
		}

		public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll(Guid programID)
		{
			return dataProgramBuilderValidates.GetAll(programID);
		}

		public int DeleteByProgramID(Guid id)
		{
			return dataProgramBuilderValidates.DeleteByProgramID(id);
		}
	}
}
