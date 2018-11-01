using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IDictionary
	{
		int Add(Dictionary model);

		int Update(Dictionary model);

		List<Dictionary> GetAll();

		Dictionary Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		Dictionary GetRoot();

		List<Dictionary> GetChilds(Guid id);

		List<Dictionary> GetChilds(string code);

		Dictionary GetParent(Guid id);

		bool HasChilds(Guid id);

		int GetMaxSort(Guid id);

		int UpdateSort(Guid id, int sort);

		Dictionary GetByCode(string code);
	}
}
