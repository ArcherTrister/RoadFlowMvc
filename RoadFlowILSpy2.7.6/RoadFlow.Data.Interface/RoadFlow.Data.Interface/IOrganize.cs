using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IOrganize
	{
		int Add(Organize model);

		int Update(Organize model);

		List<Organize> GetAll();

		Organize Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		Organize GetRoot();

		List<Organize> GetChilds(Guid ID);

		int GetMaxSort(Guid id);

		int UpdateChildsLength(Guid id, int length);

		int UpdateSort(Guid id, int sort);

		List<Organize> GetAllParent(string number);

		List<Organize> GetAllChild(string number);
	}
}
