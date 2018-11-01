using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowInstalledSub;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadFlow.Platform
{
	public class WorkFlowData
	{
		private IWorkFlowData dataWorkFlowData;

		public WorkFlowData()
		{
			dataWorkFlowData = Factory.GetWorkFlowData();
		}

		public int Add(RoadFlow.Data.Model.WorkFlowData model)
		{
			return dataWorkFlowData.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowData model)
		{
			return dataWorkFlowData.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkFlowData> GetAll()
		{
			return dataWorkFlowData.GetAll();
		}

		public RoadFlow.Data.Model.WorkFlowData Get(Guid id)
		{
			return dataWorkFlowData.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkFlowData.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkFlowData.GetCount();
		}

		public List<RoadFlow.Data.Model.WorkFlowData> GetAll(Guid instanceID)
		{
			return dataWorkFlowData.GetAll(instanceID);
		}

		public string GetFirstPrimaryKeyValue(Guid instanceID)
		{
			List<RoadFlow.Data.Model.WorkFlowData> all = GetAll(instanceID);
			if (all.Count <= 0)
			{
				return "";
			}
			return all.First().Value;
		}

		public string GetLinkFieldValue(string linkString, Guid instanceID)
		{
			string result = "";
			string[] array = linkString.Split('.');
			if (array.Length == 3)
			{
				List<RoadFlow.Data.Model.WorkFlowData> all = GetAll(instanceID);
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				foreach (RoadFlow.Data.Model.WorkFlowData item in all)
				{
					if (array[0].ToGuid() == item.LinkID && array[1] == item.TableName)
					{
						dictionary.Add(item.FieldName, item.Value);
					}
				}
				result = new DBConnection().GetFieldValue(array[2], dictionary);
			}
			return result;
		}

		public Guid CreateData(Guid flowID, string pkValue)
		{
			WorkFlowInstalled workFlowRunModel = new WorkFlow().GetWorkFlowRunModel(flowID);
			if (workFlowRunModel == null)
			{
				return Guid.Empty;
			}
			IEnumerable<DataBases> dataBases = workFlowRunModel.DataBases;
			if (dataBases.Count() == 0)
			{
				return Guid.Empty;
			}
			DataBases dataBases2 = dataBases.First();
			WorkFlowData workFlowData = new WorkFlowData();
			RoadFlow.Data.Model.WorkFlowData workFlowData2 = new RoadFlow.Data.Model.WorkFlowData
			{
				ID = Guid.NewGuid(),
				InstanceID = Guid.NewGuid(),
				LinkID = dataBases2.LinkID,
				TableName = dataBases2.Table,
				FieldName = dataBases2.PrimaryKey,
				Value = pkValue
			};
			workFlowData.Add(workFlowData2);
			return workFlowData2.InstanceID;
		}
	}
}
