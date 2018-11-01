using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWeiXinMessage
	{
		int Add(WeiXinMessage model);

		int Update(WeiXinMessage model);

		List<WeiXinMessage> GetAll();

		WeiXinMessage Get(Guid id);

		int Delete(Guid id);

		long GetCount();
	}
}
