using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class ProgramBuilderFields
	{
		private IProgramBuilderFields dataProgramBuilderFields;

		public ProgramBuilderFields()
		{
			dataProgramBuilderFields = Factory.GetProgramBuilderFields();
		}

		public int Add(RoadFlow.Data.Model.ProgramBuilderFields model)
		{
			return dataProgramBuilderFields.Add(model);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderFields model)
		{
			return dataProgramBuilderFields.Update(model);
		}

		public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll()
		{
			return dataProgramBuilderFields.GetAll();
		}

		public RoadFlow.Data.Model.ProgramBuilderFields Get(Guid id)
		{
			return dataProgramBuilderFields.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataProgramBuilderFields.Delete(id);
		}

		public long GetCount()
		{
			return dataProgramBuilderFields.GetCount();
		}

		public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll(Guid programID)
		{
			return dataProgramBuilderFields.GetAll(programID);
		}

		public int DeleteByProgramID(Guid id)
		{
			return dataProgramBuilderFields.DeleteByProgramID(id);
		}
	}
}
