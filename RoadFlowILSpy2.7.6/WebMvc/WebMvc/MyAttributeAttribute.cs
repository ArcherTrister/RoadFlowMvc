using System;

namespace WebMvc
{
	public class MyAttributeAttribute : Attribute
	{
		private bool checkLogin = true;

		private bool checkApp = true;

		private bool checkUrl = true;

		public bool CheckLogin
		{
			get
			{
				return checkLogin;
			}
			set
			{
				checkLogin = value;
			}
		}

		public bool CheckApp
		{
			get
			{
				return checkApp;
			}
			set
			{
				checkApp = value;
			}
		}

		public bool CheckUrl
		{
			get
			{
				return checkUrl;
			}
			set
			{
				checkUrl = value;
			}
		}
	}
}
