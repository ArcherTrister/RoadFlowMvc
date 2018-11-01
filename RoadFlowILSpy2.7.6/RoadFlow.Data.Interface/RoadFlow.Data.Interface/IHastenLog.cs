using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IHastenLog
	{
		int Add(HastenLog model);

		int Update(HastenLog model);

		List<HastenLog> GetAll();

		HastenLog Get(Guid id);

		int Delete(Guid id);

		long GetCount();
	}
}
