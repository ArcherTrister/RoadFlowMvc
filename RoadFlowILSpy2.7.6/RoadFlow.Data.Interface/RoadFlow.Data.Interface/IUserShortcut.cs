using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
	public interface IUserShortcut
	{
		int Add(UserShortcut model);

		int Update(UserShortcut model);

		List<UserShortcut> GetAll();

		UserShortcut Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		int DeleteByUserID(Guid userID);

		List<UserShortcut> GetAllByUserID(Guid userID);

		DataTable GetDataTableByUserID(Guid userID);

		int DeleteByMenuID(Guid menuID);
	}
}
