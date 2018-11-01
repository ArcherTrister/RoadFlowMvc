using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IShortMessage
	{
		int Add(ShortMessage model);

		int Update(ShortMessage model);

		List<ShortMessage> GetAll();

		ShortMessage Get(Guid id);

		ShortMessage GetRead(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<ShortMessage> GetAllNoRead();

		List<ShortMessage> GetAllNoReadByUserID(Guid userID);

		int UpdateStatus(Guid id);

		List<ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "");

		List<ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "");

		int Delete(string linkID, int Type);
	}
}
