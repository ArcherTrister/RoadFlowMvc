// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Wildcard
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace RoadFlow.Platform
{
  public class Wildcard
  {
    public static List<string> WildcardList = new List<string>() { "$userid$", "$username$", "$deptid$", "$deptname$", "$unitid$", "$unitname$", "$account$", "$querystring", "$queryform", "$datarow", "$date" };

    public static string GetWildcardValue(string wildcard, string userID = "")
    {
      if (wildcard.IsNullOrEmpty())
        return "";
      string str = string.Empty;
      switch (wildcard.ToLower())
      {
        case "$account$":
          if (userID.IsGuid())
          {
            RoadFlow.Data.Model.Users users = new Users().Get(userID.ToGuid());
            str = users == null ? "" : users.Account;
            break;
          }
          str = Users.CurrentUserAccount;
          break;
        case "$deptid$":
          if (userID.IsGuid())
          {
            RoadFlow.Data.Model.Organize deptByUserId = new Users().GetDeptByUserID(userID.ToGuid());
            str = deptByUserId == null ? "" : deptByUserId.ID.ToString();
            break;
          }
          str = Users.CurrentDeptID.ToString();
          break;
        case "$deptname$":
          if (userID.IsGuid())
          {
            RoadFlow.Data.Model.Organize deptByUserId = new Users().GetDeptByUserID(userID.ToGuid());
            str = deptByUserId == null ? "" : deptByUserId.Name;
            break;
          }
          str = Users.CurrentDeptName.ToString();
          break;
        case "$unitid$":
          if (userID.IsGuid())
          {
            RoadFlow.Data.Model.Organize unitByUserId = new Users().GetUnitByUserID(userID.ToGuid());
            str = unitByUserId == null ? "" : unitByUserId.ID.ToString();
            break;
          }
          str = Users.CurrentUnitID.ToString();
          break;
        case "$unitname$":
          if (userID.IsGuid())
          {
            RoadFlow.Data.Model.Organize unitByUserId = new Users().GetUnitByUserID(userID.ToGuid());
            str = unitByUserId == null ? "" : unitByUserId.Name;
            break;
          }
          str = Users.CurrentUnitName.ToString();
          break;
        case "$userid$":
          str = !userID.IsGuid() ? Users.CurrentUserID.ToString() : userID.ToString();
          break;
        case "$username$":
          if (userID.IsGuid())
          {
            RoadFlow.Data.Model.Users users = new Users().Get(userID.ToGuid());
            str = users == null ? "" : users.Name;
            break;
          }
          str = Users.CurrentUserName;
          break;
      }
      return str;
    }

    public static string FilterWildcard(string str, string userID = "", object data = null)
    {
      if (str.IsNullOrEmpty())
        return "";
      try
      {
        foreach (string wildcard in Wildcard.WildcardList)
        {
          while (str.Contains(wildcard, StringComparison.CurrentCultureIgnoreCase))
          {
            string empty = string.Empty;
            if (!(wildcard == "$querystring"))
            {
              if (!(wildcard == "$queryform"))
              {
                if (!(wildcard == "$datarow"))
                {
                  if (wildcard == "$date")
                  {
                    if (str.Contains("$date", StringComparison.CurrentCultureIgnoreCase))
                    {
                      string str1 = str.Substring(str.IndexOf("$date&") + 6);
                      string format = str1.Substring(0, str1.IndexOf("&$"));
                      string str2 = DateTimeNew.Now.ToString(format);
                      str = str.Replace1(wildcard + "&" + format + "&$", str2.IsNullOrEmpty() ? "" : str2);
                    }
                  }
                  else
                  {
                    string wildcardValue = Wildcard.GetWildcardValue(wildcard, userID);
                    str = str.Replace1(wildcard, wildcardValue.IsNullOrEmpty() ? "" : wildcardValue);
                  }
                }
                else if (str.Contains("$datarow", StringComparison.CurrentCultureIgnoreCase))
                {
                  string str1 = str.Substring(str.IndexOf("$datarow&") + 9);
                  string index = str1.Substring(0, str1.IndexOf("&$"));
                  string str2 = "";
                  if (data != null && data is DataRow)
                    str2 = ((DataRow) data)[index].ToString();
                  str = str.Replace1(wildcard + "&" + index + "&$", str2.IsNullOrEmpty() ? "" : str2);
                }
              }
              else if (str.Contains("$queryform", StringComparison.CurrentCultureIgnoreCase))
              {
                string str1 = str.Substring(str.IndexOf("$queryform&") + 11);
                string index = str1.Substring(0, str1.IndexOf("&$"));
                string str2 = HttpContext.Current.Request.Form[index];
                str = str.Replace1(wildcard + "&" + index + "&$", str2.IsNullOrEmpty() ? "" : str2);
              }
            }
            else if (str.Contains("$querystring", StringComparison.CurrentCultureIgnoreCase))
            {
              string str1 = str.Substring(str.IndexOf("$querystring&") + 13);
              string index = str1.Substring(0, str1.IndexOf("&$"));
              string str2 = HttpContext.Current.Request.QueryString[index];
              str = str.Replace1(wildcard + "&" + index + "&$", str2.IsNullOrEmpty() ? "" : str2);
            }
          }
        }
      }
      catch
      {
      }
      return str;
    }
  }
}
