using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface ISMSLog
	{
		int Add(SMSLog model);

		int Update(SMSLog model);

		List<SMSLog> GetAll();

		SMSLog Get(Guid id);

		int Delete(Guid id);

		long GetCount();
	}
}
