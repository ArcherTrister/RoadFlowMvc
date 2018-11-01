using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IDocumentDirectory
	{
		int Add(DocumentDirectory model);

		int Update(DocumentDirectory model);

		List<DocumentDirectory> GetAll();

		DocumentDirectory Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<DocumentDirectory> GetChilds(Guid id);

		int GetMaxSort(Guid dirID);
	}
}
