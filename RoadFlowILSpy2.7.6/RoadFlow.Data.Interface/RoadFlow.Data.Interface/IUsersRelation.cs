using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IUsersRelation
	{
		int Add(UsersRelation model);

		int Update(UsersRelation model);

		List<UsersRelation> GetAll();

		UsersRelation Get(Guid userid, Guid organizeid);

		int Delete(Guid userid, Guid organizeid);

		long GetCount();

		List<UsersRelation> GetAllByOrganizeID(Guid organizeID);

		List<UsersRelation> GetAllByUserID(Guid userID);

		UsersRelation GetMainByUserID(Guid userID);

		int DeleteByUserID(Guid userID);

		int DeleteNotIsMainByUserID(Guid userID);

		int DeleteByOrganizeID(Guid organizeID);

		int GetMaxSort(Guid organizeID);
	}
}
