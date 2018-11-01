using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IDocumentsReadUsers
	{
		int Add(DocumentsReadUsers model);

		int Update(DocumentsReadUsers model);

		List<DocumentsReadUsers> GetAll();

		DocumentsReadUsers Get(Guid documentid, Guid userid);

		int Delete(Guid documentid, Guid userid);

		long GetCount();

		int Delete(Guid documentid);

		void UpdateRead(Guid docID, Guid userID);
	}
}
