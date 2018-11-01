// Decompiled with JetBrains decompiler
// Type: RoadFlow.Utility.Config
// Assembly: RoadFlow.Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E4D91F62-39BF-4125-A013-6EDB7CF1B4EC
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Utility.dll

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace RoadFlow.Utility
{
  public class Config
  {
    public static string PlatformConnectionStringMSSQL
    {
      get
      {
        return ConfigurationManager.ConnectionStrings["PlatformConnection"].ConnectionString;
      }
    }

    public static string PlatformConnectionStringORACLE
    {
      get
      {
        return ConfigurationManager.ConnectionStrings["PlatformConnectionOracle"].ConnectionString;
      }
    }

    public static string PlatformConnectionStringMySql
    {
      get
      {
        return ConfigurationManager.ConnectionStrings["PlatformConnectionMySql"].ConnectionString;
      }
    }

    public static string DataBaseType
    {
      get
      {
        string appSetting = ConfigurationManager.AppSettings["DatabaseType"];
        if (!appSetting.IsNullOrEmpty())
          return appSetting.ToUpper();
        return "MSSQL";
      }
    }

    public static string SystemInitPassword
    {
      get
      {
        string appSetting = ConfigurationManager.AppSettings["InitPassword"];
        if (!appSetting.IsNullOrEmpty())
          return appSetting.Trim();
        return "111";
      }
    }

    public static string FilePath
    {
      get
      {
        string appSetting = ConfigurationManager.AppSettings[nameof (FilePath)];
        if (appSetting.IsNullOrEmpty())
          return "d:\\RoadFlowFiles\\";
        if (!appSetting.EndsWith("\\"))
          return appSetting + "\\";
        return appSetting;
      }
    }

    public static string Theme
    {
      get
      {
        HttpCookie cookie = HttpContext.Current.Request.Cookies["theme_platform"];
        if (cookie == null || cookie.Value.IsNullOrEmpty())
          return "Blue";
        return cookie.Value;
      }
    }

    public static string UploadFileType
    {
      get
      {
        return ConfigurationManager.AppSettings[nameof (UploadFileType)];
      }
    }

    public static bool IsDemo
    {
      get
      {
        return "1".Equals(ConfigurationManager.AppSettings[nameof (IsDemo)]);
      }
    }

    public static string DateFormat
    {
      get
      {
        return "yyyy-MM-dd";
      }
    }

    public static string DateTimeFormat
    {
      get
      {
        return "yyyy-MM-dd HH:mm";
      }
    }

    public static string DateTimeFormatS
    {
      get
      {
        return "yyyy-MM-dd HH:mm:ss";
      }
    }

    public static List<string> SystemDataTables
    {
      get
      {
        List<string> stringList = new List<string>();
        string appSetting = ConfigurationManager.AppSettings["SystemTables"];
        if (appSetting.IsNullOrEmpty())
          return stringList;
        string str1 = appSetting;
        char[] chArray = new char[1]{ ',' };
        foreach (string str2 in str1.Split(chArray))
        {
          if (!str2.IsNullOrEmpty())
            stringList.Add(str2);
        }
        return stringList;
      }
    }

    public static string BaseUrl
    {
      get
      {
        string domainAppVirtualPath = HttpRuntime.AppDomainAppVirtualPath;
        if (!(domainAppVirtualPath == "/"))
          return domainAppVirtualPath;
        return "";
      }
    }

    public static string GetTokenByUserId(Guid userID)
    {
      Guid guid = Guid.NewGuid();
      return (userID.ToString() + "|" + guid.ToString()).DesEncrypt();
    }

    public static Guid? GetUserIdByToken(string token)
    {
      if (token.IsNullOrEmpty())
        return new Guid?();
      string str1 = token.DesDecrypt();
      if (str1.IsNullOrEmpty())
        return new Guid?();
      string[] strArray = str1.Split('|');
      if (strArray == null || strArray.Length != 2)
        return new Guid?();
      string str2 = strArray[0];
      if (!str2.IsGuid())
        return new Guid?();
      return new Guid?(str2.ToGuid());
    }
  }
}
