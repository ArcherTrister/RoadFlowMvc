// Decompiled with JetBrains decompiler
// Type: MyExtensions1
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

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
        if (MyExtensions.IsNullOrEmpty(wildcard))
        {
            return "";
        }
        string result = string.Empty;
        switch (wildcard.ToLower())
        {
            case "$userid$":
                result = ((!MyExtensions.IsGuid(userID)) ? RoadFlow.Platform.Users.CurrentUserID.ToString() : userID.ToString());
                break;
            case "$username$":
                if (MyExtensions.IsGuid(userID))
                {
                    RoadFlow.Data.Model.Users users2 = new RoadFlow.Platform.Users().Get(MyExtensions.ToGuid(userID));
                    result = ((users2 == null) ? "" : users2.Name);
                }
                else
                {
                    result = RoadFlow.Platform.Users.CurrentUserName;
                }
                break;
            case "$deptid$":
                if (MyExtensions.IsGuid(userID))
                {
                    RoadFlow.Data.Model.Organize deptByUserID2 = new RoadFlow.Platform.Users().GetDeptByUserID(MyExtensions.ToGuid(userID));
                    result = ((deptByUserID2 == null) ? "" : deptByUserID2.ID.ToString());
                }
                else
                {
                    result = RoadFlow.Platform.Users.CurrentDeptID.ToString();
                }
                break;
            case "$deptname$":
                if (MyExtensions.IsGuid(userID))
                {
                    RoadFlow.Data.Model.Organize deptByUserID = new RoadFlow.Platform.Users().GetDeptByUserID(MyExtensions.ToGuid(userID));
                    result = ((deptByUserID == null) ? "" : deptByUserID.Name);
                }
                else
                {
                    result = RoadFlow.Platform.Users.CurrentDeptName.ToString();
                }
                break;
            case "$unitid$":
                if (MyExtensions.IsGuid(userID))
                {
                    RoadFlow.Data.Model.Organize unitByUserID = new RoadFlow.Platform.Users().GetUnitByUserID(MyExtensions.ToGuid(userID));
                    result = ((unitByUserID == null) ? "" : unitByUserID.ID.ToString());
                }
                else
                {
                    result = RoadFlow.Platform.Users.CurrentUnitID.ToString();
                }
                break;
            case "$unitname$":
                if (MyExtensions.IsGuid(userID))
                {
                    RoadFlow.Data.Model.Organize unitByUserID2 = new RoadFlow.Platform.Users().GetUnitByUserID(MyExtensions.ToGuid(userID));
                    result = ((unitByUserID2 == null) ? "" : unitByUserID2.Name);
                }
                else
                {
                    result = RoadFlow.Platform.Users.CurrentUnitName.ToString();
                }
                break;
            case "$account$":
                if (MyExtensions.IsGuid(userID))
                {
                    RoadFlow.Data.Model.Users users = new RoadFlow.Platform.Users().Get(MyExtensions.ToGuid(userID));
                    result = ((users == null) ? "" : users.Account);
                }
                else
                {
                    result = RoadFlow.Platform.Users.CurrentUserAccount;
                }
                break;
        }
        return result;
    }

    public static string FilterWildcard(string str, string userID = "", object data = null)
    {
        if (!MyExtensions.IsNullOrEmpty(str))
        {
            try
            {
                foreach (string wildcard in WildcardList)
                {
                    while (MyExtensions.Contains(str, wildcard, StringComparison.CurrentCultureIgnoreCase))
                    {
                        string empty = string.Empty;
                        switch (wildcard)
                        {
                            case "$querystring":
                                if (MyExtensions.Contains(str, "$querystring", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    string text = str.Substring(str.IndexOf("$querystring&") + 13);
                                    text = text.Substring(0, text.IndexOf("&$"));
                                    empty = HttpContext.Current.Request.QueryString[text];
                                    str = MyExtensions.Replace1(str, wildcard + "&" + text + "&$", MyExtensions.IsNullOrEmpty(empty) ? "" : empty);
                                }
                                break;
                            case "$queryform":
                                if (MyExtensions.Contains(str, "$queryform", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    string text2 = str.Substring(str.IndexOf("$queryform&") + 11);
                                    text2 = text2.Substring(0, text2.IndexOf("&$"));
                                    empty = HttpContext.Current.Request.Form[text2];
                                    str = MyExtensions.Replace1(str, wildcard + "&" + text2 + "&$", MyExtensions.IsNullOrEmpty(empty) ? "" : empty);
                                }
                                break;
                            case "$datarow":
                                if (MyExtensions.Contains(str, "$datarow", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    string text3 = str.Substring(str.IndexOf("$datarow&") + 9);
                                    text3 = text3.Substring(0, text3.IndexOf("&$"));
                                    empty = "";
                                    if (data != null && data is DataRow)
                                    {
                                        empty = ((DataRow)data)[text3].ToString();
                                    }
                                    str = MyExtensions.Replace1(str, wildcard + "&" + text3 + "&$", MyExtensions.IsNullOrEmpty(empty) ? "" : empty);
                                }
                                break;
                            case "$date":
                                if (MyExtensions.Contains(str, "$date", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    string text4 = str.Substring(str.IndexOf("$date&") + 6);
                                    text4 = text4.Substring(0, text4.IndexOf("&$"));
                                    empty = DateTimeNew.Now.ToString(text4);
                                    str = MyExtensions.Replace1(str, wildcard + "&" + text4 + "&$", MyExtensions.IsNullOrEmpty(empty) ? "" : empty);
                                }
                                break;
                            default:
                                empty = GetWildcardValue(wildcard, userID);
                                str = MyExtensions.Replace1(str, wildcard, MyExtensions.IsNullOrEmpty(empty) ? "" : empty);
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
