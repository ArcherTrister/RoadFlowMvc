// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Files
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using Microsoft.Win32;
using RoadFlow.Cache.IO;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace RoadFlow.Platform
{
  public class Files
  {
    public static string FilePath = Config.FilePath;

    public string GetUserDirectoryJson(Guid userID, string path = "", bool isFirst = false)
    {
      path = path.IsNullOrEmpty() ? this.GetUserRootPath(userID) : path;
      string[] directories = Directory.GetDirectories(path);
      JsonData jsonData1 = new JsonData();
      if (isFirst)
      {
        jsonData1["id"] = (JsonData) path.DesEncrypt();
        jsonData1["parentID"] = (JsonData) "0";
        jsonData1["title"] = (JsonData) "我的文件";
        jsonData1["type"] = (JsonData) 0;
        jsonData1["ico"] = (JsonData) "";
        jsonData1["hasChilds"] = (JsonData) (directories.Length != 0 ? "1" : "0");
        if (directories.Length != 0)
          jsonData1["childs"] = new JsonData();
      }
      foreach (string str in directories)
      {
        bool flag = (uint) Directory.GetDirectories(str).Length > 0U;
        string fileName = Path.GetFileName(str);
        JsonData jsonData2 = new JsonData();
        jsonData2["id"] = (JsonData) str.DesEncrypt();
        jsonData2["parentID"] = (JsonData) path.DesEncrypt();
        jsonData2["title"] = (JsonData) fileName;
        jsonData2["type"] = (JsonData) 1;
        jsonData2["hasChilds"] = (JsonData) (flag ? "1" : "0");
        jsonData2["ico"] = (JsonData) (flag ? "" : "fa-folder");
        if (isFirst)
          jsonData1["childs"].Add((object) jsonData2);
        else
          jsonData1.Add((object) jsonData2);
      }
      //return jsonData1.ToJson(true);
            return jsonData1.ToJson();
        }

    public List<RoadFlow.Data.Model.Files> GetList(string path)
    {
      List<RoadFlow.Data.Model.Files> filesList = new List<RoadFlow.Data.Model.Files>();
      if (!Directory.Exists(path))
        return filesList;
      DirectoryInfo directoryInfo = new DirectoryInfo(path);
      foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
        filesList.Add(new RoadFlow.Data.Model.Files()
        {
          CreateTime = directory.CreationTime,
          FileLength = new int?(directory.GetFiles().Length),
          FullName = directory.FullName,
          ModifyTime = directory.LastWriteTime,
          Name = directory.Name,
          Type = 0
        });
      foreach (FileInfo file in directoryInfo.GetFiles())
        filesList.Add(new RoadFlow.Data.Model.Files()
        {
          CreateTime = file.CreationTime,
          Length = new Decimal?((Decimal) file.Length),
          ModifyTime = file.LastWriteTime,
          Name = file.Name,
          FullName = file.FullName,
          Type = 1
        });
      return filesList;
    }

    public string GetRootPath()
    {
      return Files.FilePath;
    }

    public string GetUserRootPath(Guid userID)
    {
      string path = Files.FilePath + "UserFiles\\" + userID.ToString();
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      return path;
    }

    public string GetUploadPath()
    {
      DateTime now = DateTimeNew.Now;
      string path = Files.FilePath + "UploadFiles\\" + (object) now.Year + "\\" + (object) now.Month + "\\" + (object) now.Day;
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      return path;
    }

    public bool CreateDirectory(string path, string dirName)
    {
      if (path.IsNullOrEmpty() || dirName.IsNullOrEmpty())
        return false;
      string path1 = Path.Combine(path, dirName);
      if (!Directory.Exists(path1))
        return Directory.CreateDirectory(path1) != null;
      return true;
    }

    public string Delete(string pathOrFile)
    {
      StringBuilder stringBuilder = new StringBuilder();
      FileInfo fileInfo = new FileInfo(pathOrFile);
      if (fileInfo.Exists)
      {
        try
        {
          fileInfo.Delete();
        }
        catch (IOException ex)
        {
          stringBuilder.Append(fileInfo.Name + "删除失败;");
          Log.Add((Exception) ex);
        }
      }
      DirectoryInfo directoryInfo = new DirectoryInfo(pathOrFile);
      if (directoryInfo.Exists)
      {
        try
        {
          directoryInfo.Delete(true);
        }
        catch (IOException ex)
        {
          stringBuilder.Append(directoryInfo.Name + "删除失败;");
          Log.Add((Exception) ex);
        }
      }
      return stringBuilder.ToString();
    }

    public string GetFileContentType(string fileExtension)
    {
      if (fileExtension.IsNullOrEmpty())
        return "";
      string key = Keys.CacheKeys.FileContentType.ToString();
      object obj = Opation.Get(key);
      List<Tuple<string, string>> tupleList = new List<Tuple<string, string>>();
      if (obj != null)
        tupleList = (List<Tuple<string, string>>) obj;
      Tuple<string, string> tuple = tupleList.Find((Predicate<Tuple<string, string>>) (p => p.Item1.Equals(fileExtension, StringComparison.CurrentCultureIgnoreCase)));
      if (tuple != null)
        return tuple.Item2;
      try
      {
        string str = Registry.GetValue("HKEY_CLASSES_ROOT\\" + fileExtension, "Content Type", (object) string.Empty).ToString();
        if (!str.IsNullOrEmpty())
        {
          tupleList.Add(new Tuple<string, string>(fileExtension, str));
          Opation.Set(key, (object) tupleList);
          return str;
        }
      }
      catch
      {
      }
      return "";
    }

    public static string GetFilesShowString(string files, string showUrl = "", bool showImg = false, bool newRow = true)
    {
      if (files.IsNullOrEmpty())
        return "";
      if (showUrl.IsNullOrEmpty())
        showUrl = !(HttpContext.Current.Request.Url != (Uri) null) || !HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".aspx", StringComparison.CurrentCultureIgnoreCase) && !HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".ashx", StringComparison.CurrentCultureIgnoreCase) ? Config.BaseUrl + "/Content/Show.ashx" : Config.BaseUrl + "/Platform/Files/Show.ashx";
      if (showUrl.IsNullOrEmpty())
        return "";
      string[] strArray = files.Split('|');
      StringBuilder stringBuilder = new StringBuilder();
      int num = 0;
      foreach (string str1 in strArray)
      {
        string str2 = Files.FilePath + str1.DesDecrypt();
        if (File.Exists(str2))
        {
          string str3 = " style=\"vertical-align:middle;";
          string str4 = (newRow ? str3 + "margin:8px 0;" : str3 + "float:left;margin:8px 8px 0 0;") + "\"";
          if (showImg && Files.IsImage(str2))
            stringBuilder.AppendFormat("<div{0}><img src=\"{1}\" style=\"border:none 0;\"/></div>", (object) str4, (object) (showUrl + "?id=" + str2.DesEncrypt()));
          else
            stringBuilder.AppendFormat("<div{0}><a target=\"_blank\" href=\"{1}\" class=\"blue1\">{2}</a></div>", (object) str4, (object) (showUrl + "?id=" + str2.DesEncrypt()), (object) ((++num).ToString() + "、" + Path.GetFileName(str2)));
        }
      }
      stringBuilder.Append("<div style=\"clear:both;\"></div>");
      return stringBuilder.ToString();
    }

    public static bool IsImage(string file)
    {
      string extension = Path.GetExtension(file);
      if (extension.IsNullOrEmpty())
        return false;
      if (!(extension.ToLower() == ".jpg") && !(extension.ToLower() == ".jpeg") && (!(extension.ToLower() == ".png") && !(extension.ToLower() == ".gif")))
        return extension.ToLower() == ".bmp";
      return true;
    }
  }
}
