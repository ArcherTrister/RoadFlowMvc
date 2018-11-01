using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class Users
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("姓名")]
		public string Name
		{
			get;
			set;
		}

		[DisplayName("帐号")]
		public string Account
		{
			get;
			set;
		}

		[DisplayName("密码")]
		public string Password
		{
			get;
			set;
		}

		[DisplayName("状态 0 正常 1 冻结")]
		public int Status
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

		[DisplayName("备注")]
		public string Note
		{
			get;
			set;
		}

		[DisplayName("手机")]
		public string Mobile
		{
			get;
			set;
		}

		[DisplayName("办公电话")]
		public string Tel
		{
			get;
			set;
		}

		[DisplayName("其它联系方式")]
		public string OtherTel
		{
			get;
			set;
		}

		[DisplayName("传真")]
		public string Fax
		{
			get;
			set;
		}

		[DisplayName("邮箱")]
		public string Email
		{
			get;
			set;
		}

		[DisplayName("QQ")]
		public string QQ
		{
			get;
			set;
		}

		[DisplayName("头像")]
		public string HeadImg
		{
			get;
			set;
		}

		[DisplayName("微信号")]
		public string WeiXin
		{
			get;
			set;
		}

		[DisplayName("性别 0男 1女")]
		public int? Sex
		{
			get;
			set;
		}
	}
}
