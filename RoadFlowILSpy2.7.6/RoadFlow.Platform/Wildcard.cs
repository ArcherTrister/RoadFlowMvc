using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace RoadFlow.Platform
{
	public class Wildcard
	{
		public static List<string> WildcardList = new List<string>
		{
			"$userid$",
			"$username$",
			"$deptid$",
			"$deptname$",
			"$unitid$",
			"$unitname$",
			"$account$",
			"$querystring",
			"$queryform",
			"$datarow",
			"$date"
		};

		public static string GetWildcardValue(string wildcard, string userID = "")
		{
			if (wildcard.IsNullOrEmpty())
			{
				return "";
			}
			string result = string.Empty;
			switch (wildcard.ToLower())
			{
			case "$userid$":
				result = ((!userID.IsGuid()) ? Users.CurrentUserID.ToString() : userID.ToString());
				break;
			case "$username$":
				if (userID.IsGuid())
				{
					RoadFlow.Data.Model.Users users2 = new Users().Get(userID.ToGuid());
					result = ((users2 == null) ? "" : users2.Name);
				}
				else
				{
					result = Users.CurrentUserName;
				}
				break;
			case "$deptid$":
				if (userID.IsGuid())
				{
					RoadFlow.Data.Model.Organize deptByUserID2 = new Users().GetDeptByUserID(userID.ToGuid());
					result = ((deptByUserID2 == null) ? "" : deptByUserID2.ID.ToString());
				}
				else
				{
					result = Users.CurrentDeptID.ToString();
				}
				break;
			case "$deptname$":
				if (userID.IsGuid())
				{
					RoadFlow.Data.Model.Organize deptByUserID = new Users().GetDeptByUserID(userID.ToGuid());
					result = ((deptByUserID == null) ? "" : deptByUserID.Name);
				}
				else
				{
					result = Users.CurrentDeptName.ToString();
				}
				break;
			case "$unitid$":
				if (userID.IsGuid())
				{
					RoadFlow.Data.Model.Organize unitByUserID = new Users().GetUnitByUserID(userID.ToGuid());
					result = ((unitByUserID == null) ? "" : unitByUserID.ID.ToString());
				}
				else
				{
					result = Users.CurrentUnitID.ToString();
				}
				break;
			case "$unitname$":
				if (userID.IsGuid())
				{
					RoadFlow.Data.Model.Organize unitByUserID2 = new Users().GetUnitByUserID(userID.ToGuid());
					result = ((unitByUserID2 == null) ? "" : unitByUserID2.Name);
				}
				else
				{
					result = Users.CurrentUnitName.ToString();
				}
				break;
			case "$account$":
				if (userID.IsGuid())
				{
					RoadFlow.Data.Model.Users users = new Users().Get(userID.ToGuid());
					result = ((users == null) ? "" : users.Account);
				}
				else
				{
					result = Users.CurrentUserAccount;
				}
				break;
			}
			return result;
		}

		public static string FilterWildcard(string str, string userID = "", object data = null)
		{
			if (!str.IsNullOrEmpty())
			{
				try
				{
					foreach (string wildcard in WildcardList)
					{
						while (str.Contains(wildcard, StringComparison.CurrentCultureIgnoreCase))
						{
							string empty = string.Empty;
							switch (wildcard)
							{
							case "$querystring":
								if (str.Contains("$querystring", StringComparison.CurrentCultureIgnoreCase))
								{
									string text = str.Substring(str.IndexOf("$querystring&") + 13);
									text = text.Substring(0, text.IndexOf("&$"));
									empty = HttpContext.Current.Request.QueryString[text];
									str = str.Replace1(wildcard + "&" + text + "&$", empty.IsNullOrEmpty() ? "" : empty);
								}
								break;
							case "$queryform":
								if (str.Contains("$queryform", StringComparison.CurrentCultureIgnoreCase))
								{
									string text2 = str.Substring(str.IndexOf("$queryform&") + 11);
									text2 = text2.Substring(0, text2.IndexOf("&$"));
									empty = HttpContext.Current.Request.Form[text2];
									str = str.Replace1(wildcard + "&" + text2 + "&$", empty.IsNullOrEmpty() ? "" : empty);
								}
								break;
							case "$datarow":
								if (str.Contains("$datarow", StringComparison.CurrentCultureIgnoreCase))
								{
									string text3 = str.Substring(str.IndexOf("$datarow&") + 9);
									text3 = text3.Substring(0, text3.IndexOf("&$"));
									empty = "";
									if (data != null && data is DataRow)
									{
										empty = ((DataRow)data)[text3].ToString();
									}
									str = str.Replace1(wildcard + "&" + text3 + "&$", empty.IsNullOrEmpty() ? "" : empty);
								}
								break;
							case "$date":
								if (str.Contains("$date", StringComparison.CurrentCultureIgnoreCase))
								{
									string text4 = str.Substring(str.IndexOf("$date&") + 6);
									text4 = text4.Substring(0, text4.IndexOf("&$"));
									empty = DateTimeNew.Now.ToString(text4);
									str = str.Replace1(wildcard + "&" + text4 + "&$", empty.IsNullOrEmpty() ? "" : empty);
								}
								break;
							default:
								empty = GetWildcardValue(wildcard, userID);
								str = str.Replace1(wildcard, empty.IsNullOrEmpty() ? "" : empty);
								break;
							}
						}
					}
					return str;
				}
				catch
				{
					return str;
				}
			}
			return "";
		}
	}
}
