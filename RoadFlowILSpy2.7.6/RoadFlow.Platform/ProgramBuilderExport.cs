using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Platform
{
	public class ProgramBuilderExport
	{
		private IProgramBuilderExport dataProgramBuilderExport;

		public ProgramBuilderExport()
		{
			dataProgramBuilderExport = Factory.GetProgramBuilderExport();
		}

		public int Add(RoadFlow.Data.Model.ProgramBuilderExport model)
		{
			return dataProgramBuilderExport.Add(model);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderExport model)
		{
			return dataProgramBuilderExport.Update(model);
		}

		public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll()
		{
			return dataProgramBuilderExport.GetAll();
		}

		public RoadFlow.Data.Model.ProgramBuilderExport Get(Guid id)
		{
			return dataProgramBuilderExport.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataProgramBuilderExport.Delete(id);
		}

		public long GetCount()
		{
			return dataProgramBuilderExport.GetCount();
		}

		public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll(Guid programID)
		{
			return dataProgramBuilderExport.GetAll(programID);
		}

		public string GetDataTypeOptions(string value)
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			dictionary.Add(0, "常规");
			dictionary.Add(1, "文本");
			dictionary.Add(2, "数字");
			dictionary.Add(3, "日期时间");
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, string> item in dictionary)
			{
				stringBuilder.Append("<option value=\"" + dictionary.Keys.ToString() + "\"" + ((dictionary.Keys.ToString() == value) ? " selected=\"selected\"" : "") + ">" + item.Value + "</option>");
			}
			return stringBuilder.ToString();
		}
	}
}
