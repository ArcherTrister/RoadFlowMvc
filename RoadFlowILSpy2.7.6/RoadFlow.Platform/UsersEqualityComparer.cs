using RoadFlow.Data.Model;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class UsersEqualityComparer : IEqualityComparer<RoadFlow.Data.Model.Users>
	{
		public bool Equals(RoadFlow.Data.Model.Users user1, RoadFlow.Data.Model.Users user2)
		{
			if (user1 != null && user2 != null)
			{
				return user1.ID == user2.ID;
			}
			return true;
		}

		public int GetHashCode(RoadFlow.Data.Model.Users user)
		{
			return user.ToString().GetHashCode();
		}
	}
}
