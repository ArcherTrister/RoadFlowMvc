using System;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class OnlineUsers
	{
		public Guid ID
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string OrgName
		{
			get;
			set;
		}

		public string IP
		{
			get;
			set;
		}

		public string ClientInfo
		{
			get;
			set;
		}

		public string LastPage
		{
			get;
			set;
		}

		public DateTime LoginTime
		{
			get;
			set;
		}

		public Guid UniqueID
		{
			get;
			set;
		}
	}
}
