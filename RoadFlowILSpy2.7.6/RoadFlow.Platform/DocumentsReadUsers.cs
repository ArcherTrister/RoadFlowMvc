using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class DocumentsReadUsers
	{
		private IDocumentsReadUsers dataDocumentsReadUsers;

		public DocumentsReadUsers()
		{
			dataDocumentsReadUsers = Factory.GetDocumentsReadUsers();
		}

		public int Add(RoadFlow.Data.Model.DocumentsReadUsers model)
		{
			return dataDocumentsReadUsers.Add(model);
		}

		public int Update(RoadFlow.Data.Model.DocumentsReadUsers model)
		{
			return dataDocumentsReadUsers.Update(model);
		}

		public List<RoadFlow.Data.Model.DocumentsReadUsers> GetAll()
		{
			return dataDocumentsReadUsers.GetAll();
		}

		public RoadFlow.Data.Model.DocumentsReadUsers Get(Guid documentid, Guid userid)
		{
			return dataDocumentsReadUsers.Get(documentid, userid);
		}

		public int Delete(Guid documentid, Guid userid)
		{
			return dataDocumentsReadUsers.Delete(documentid, userid);
		}

		public long GetCount()
		{
			return dataDocumentsReadUsers.GetCount();
		}

		public int Delete(Guid documentid)
		{
			return dataDocumentsReadUsers.Delete(documentid);
		}

		public void UpdateRead(Guid docID, Guid userID)
		{
			dataDocumentsReadUsers.UpdateRead(docID, userID);
		}
	}
}
