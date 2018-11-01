using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class UsersRelation
	{
		private IUsersRelation dataUsersRelation;

		public UsersRelation()
		{
			dataUsersRelation = Factory.GetUsersRelation();
		}

		public int Add(RoadFlow.Data.Model.UsersRelation model)
		{
			return dataUsersRelation.Add(model);
		}

		public int Update(RoadFlow.Data.Model.UsersRelation model)
		{
			return dataUsersRelation.Update(model);
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAll()
		{
			return dataUsersRelation.GetAll();
		}

		public RoadFlow.Data.Model.UsersRelation Get(Guid userid, Guid organizeid)
		{
			return dataUsersRelation.Get(userid, organizeid);
		}

		public int Delete(Guid userid, Guid organizeid)
		{
			if (Config.IsDemo)
			{
				return 0;
			}
			return dataUsersRelation.Delete(userid, organizeid);
		}

		public long GetCount()
		{
			return dataUsersRelation.GetCount();
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAllByOrganizeID(Guid organizeID)
		{
			return dataUsersRelation.GetAllByOrganizeID(organizeID);
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAllByUserID(Guid userID)
		{
			return dataUsersRelation.GetAllByUserID(userID);
		}

		public RoadFlow.Data.Model.UsersRelation GetMainByUserID(Guid userID)
		{
			return dataUsersRelation.GetMainByUserID(userID);
		}

		public int DeleteByUserID(Guid userID)
		{
			if (Config.IsDemo)
			{
				return 0;
			}
			return dataUsersRelation.DeleteByUserID(userID);
		}

		public int DeleteNotIsMainByUserID(Guid userID)
		{
			return dataUsersRelation.DeleteNotIsMainByUserID(userID);
		}

		public int DeleteByOrganizeID(Guid organizeID)
		{
			return dataUsersRelation.DeleteByOrganizeID(organizeID);
		}

		public int GetMaxSort(Guid organizeID)
		{
			return dataUsersRelation.GetMaxSort(organizeID);
		}
	}
}
