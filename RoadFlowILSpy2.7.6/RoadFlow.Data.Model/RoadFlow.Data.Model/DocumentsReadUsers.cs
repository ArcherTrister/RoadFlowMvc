using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class DocumentsReadUsers
	{
		[DisplayName("DocumentID")]
		public Guid DocumentID
		{
			get;
			set;
		}

		[DisplayName("UserID")]
		public Guid UserID
		{
			get;
			set;
		}

		[DisplayName("IsRead")]
		public int IsRead
		{
			get;
			set;
		}
	}
}
