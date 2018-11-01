using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IMenuUser
	{
		int Add(MenuUser model);

		int Update(MenuUser model);

		List<MenuUser> GetAll();

		MenuUser Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		int DeleteByOrganizes(string organizes);

		int DeleteByMenuID(Guid menuID);
	}
}
