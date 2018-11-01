using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class WorkFlowButtons
	{
		private IWorkFlowButtons dataWorkFlowButtons;

		public WorkFlowButtons()
		{
			dataWorkFlowButtons = Factory.GetWorkFlowButtons();
		}

		public int Add(RoadFlow.Data.Model.WorkFlowButtons model)
		{
			return dataWorkFlowButtons.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowButtons model)
		{
			return dataWorkFlowButtons.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkFlowButtons> GetAll(bool fromCache = false)
		{
			if (fromCache)
			{
				string key = 4.ToString();
				object obj = Opation.Get(key);
				if (obj != null && obj is List<RoadFlow.Data.Model.WorkFlowButtons>)
				{
					return (List<RoadFlow.Data.Model.WorkFlowButtons>)obj;
				}
				List<RoadFlow.Data.Model.WorkFlowButtons> all = dataWorkFlowButtons.GetAll();
				Opation.Set(key, all);
				return all;
			}
			return dataWorkFlowButtons.GetAll();
		}

		public RoadFlow.Data.Model.WorkFlowButtons Get(Guid id, bool fromCache = false)
		{
			if (fromCache)
			{
				RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = GetAll(true).Find((RoadFlow.Data.Model.WorkFlowButtons p) => p.ID == id);
				if (workFlowButtons != null)
				{
					return workFlowButtons;
				}
				return dataWorkFlowButtons.Get(id);
			}
			return dataWorkFlowButtons.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkFlowButtons.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkFlowButtons.GetCount();
		}

		public void ClearCache()
		{
			Opation.Remove(4.ToString());
		}

		public int GetMaxSort()
		{
			return dataWorkFlowButtons.GetMaxSort();
		}
	}
}
