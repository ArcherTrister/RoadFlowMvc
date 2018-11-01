using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class WeiXinMessage
	{
		private IWeiXinMessage dataWeiXinMessage;

		public WeiXinMessage()
		{
			dataWeiXinMessage = Factory.GetWeiXinMessage();
		}

		public int Add(RoadFlow.Data.Model.WeiXinMessage model)
		{
			return dataWeiXinMessage.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WeiXinMessage model)
		{
			return dataWeiXinMessage.Update(model);
		}

		public List<RoadFlow.Data.Model.WeiXinMessage> GetAll()
		{
			return dataWeiXinMessage.GetAll();
		}

		public RoadFlow.Data.Model.WeiXinMessage Get(Guid id)
		{
			return dataWeiXinMessage.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWeiXinMessage.Delete(id);
		}

		public long GetCount()
		{
			return dataWeiXinMessage.GetCount();
		}
	}
}
