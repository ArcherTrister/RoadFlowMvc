using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class UsersRelation
	{
		[DisplayName("人员ID")]
		public Guid UserID
		{
			get;
			set;
		}

		[DisplayName("组织机构ID")]
		public Guid OrganizeID
		{
			get;
			set;
		}

		[DisplayName("是否主要岗位/部门")]
		public int IsMain
		{
			get;
			set;
		}

		[DisplayName("排序")]
		public int Sort
		{
			get;
			set;
		}
	}
}
