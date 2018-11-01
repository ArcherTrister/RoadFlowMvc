using LitJson;
using Microsoft.Win32;
using RoadFlow.Cache.IO;
using RoadFlow.Data.Model;
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
			path = (path.IsNullOrEmpty() ? GetUserRootPath(userID) : path);
			string[] directories = Directory.GetDirectories(path);
			JsonData jsonData = new JsonData();
			if (isFirst)
			{
				jsonData["id"] = path.DesEncrypt();
				jsonData["parentID"] = "0";
				jsonData["title"] = "我的文件";
				jsonData["type"] = 0;
				jsonData["ico"] = "";
				jsonData["hasChilds"] = ((directories.Length != 0) ? "1" : "0");
				if (directories.Length != 0)
				{
					jsonData["childs"] = new JsonData();
				}
			}
			string[] array = directories;
			foreach (string text in array)
			{
				bool flag = Directory.GetDirectories(text).Length != 0;
				string fileName = Path.GetFileName(text);
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = text.DesEncrypt();
				jsonData2["parentID"] = path.DesEncrypt();
				jsonData2["title"] = fileName;
				jsonData2["type"] = 1;
				jsonData2["hasChilds"] = (flag ? "1" : "0");
				jsonData2["ico"] = (flag ? "" : "fa-folder");
				if (isFirst)
				{
					jsonData["childs"].Add(jsonData2);
				}
				else
				{
					jsonData.Add(jsonData2);
				}
			}
			return jsonData.ToJson();
		}

		public List<RoadFlow.Data.Model.Files> GetList(string path)
		{
			List<RoadFlow.Data.Model.Files> list = new List<RoadFlow.Data.Model.Files>();
			if (!Directory.Exists(path))
			{
				return list;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				RoadFlow.Data.Model.Files files = new RoadFlow.Data.Model.Files();
				files.CreateTime = directoryInfo2.CreationTime;
				files.FileLength = directoryInfo2.GetFiles().Length;
				files.FullName = directoryInfo2.FullName;
				files.ModifyTime = directoryInfo2.LastWriteTime;
				files.Name = directoryInfo2.Name;
				files.Type = 0;
				list.Add(files);
			}
			FileInfo[] files2 = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files2)
			{
				RoadFlow.Data.Model.Files files3 = new RoadFlow.Data.Model.Files();
				files3.CreateTime = fileInfo.CreationTime;
				files3.Length = fileInfo.Length;
				files3.ModifyTime = fileInfo.LastWriteTime;
				files3.Name = fileInfo.Name;
				files3.FullName = fileInfo.FullName;
				files3.Type = 1;
				list.Add(files3);
			}
			return list;
		}

		public string GetRootPath()
		{
			return FilePath;
		}

		public string GetUserRootPath(Guid userID)
		{
			string text = FilePath + "UserFiles\\" + userID.ToString();
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		public string GetUploadPath()
		{
			DateTime now = DateTimeNew.Now;
			string text = FilePath + "UploadFiles\\" + now.Year + "\\" + now.Month + "\\" + now.Day;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		public bool CreateDirectory(string path, string dirName)
		{
			if (path.IsNullOrEmpty() || dirName.IsNullOrEmpty())
			{
				return false;
			}
			string path2 = Path.Combine(path, dirName);
			if (!Directory.Exists(path2))
			{
				return Directory.CreateDirectory(path2) != null;
			}
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
				catch (IOException err)
				{
					stringBuilder.Append(fileInfo.Name + "删除失败;");
					Log.Add(err);
				}
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(pathOrFile);
			if (directoryInfo.Exists)
			{
				try
				{
					directoryInfo.Delete(true);
				}
				catch (IOException err2)
				{
					stringBuilder.Append(directoryInfo.Name + "删除失败;");
					Log.Add(err2);
				}
			}
			return stringBuilder.ToString();
		}

		public string GetFileContentType(string fileExtension)
		{
			if (fileExtension.IsNullOrEmpty())
			{
				return "";
			}
			string key = 22.ToString();
			object obj = Opation.Get(key);
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			if (obj != null)
			{
				list = (List<Tuple<string, string>>)obj;
			}
			Tuple<string, string> tuple = list.Find((Tuple<string, string> p) => p.Item1.Equals(fileExtension, StringComparison.CurrentCultureIgnoreCase));
			if (tuple != null)
			{
				return tuple.Item2;
			}
			try
			{
				string text = Registry.GetValue("HKEY_CLASSES_ROOT\\" + fileExtension, "Content Type", string.Empty).ToString();
				if (!text.IsNullOrEmpty())
				{
					list.Add(new Tuple<string, string>(fileExtension, text));
					Opation.Set(key, list);
					return text;
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
			{
				return "";
			}
			if (showUrl.IsNullOrEmpty())
			{
				showUrl = ((!(HttpContext.Current.Request.Url != null) || (!HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".aspx", StringComparison.CurrentCultureIgnoreCase) && !HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".ashx", StringComparison.CurrentCultureIgnoreCase))) ? (Config.BaseUrl + "/Content/Show.ashx") : (Config.BaseUrl + "/Platform/Files/Show.ashx"));
			}
			if (showUrl.IsNullOrEmpty())
			{
				return "";
			}
			string[] array = files.Split('|');
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			string[] array2 = array;
			foreach (string str in array2)
			{
				string text = FilePath + str.DesDecrypt();
				if (File.Exists(text))
				{
					string str2 = " style=\"vertical-align:middle;";
					str2 = (newRow ? (str2 + "margin:8px 0;") : (str2 + "float:left;margin:8px 8px 0 0;"));
					str2 += "\"";
					if (showImg && IsImage(text))
					{
						stringBuilder.AppendFormat("<div{0}><img src=\"{1}\" style=\"border:none 0;\"/></div>", str2, showUrl + "?id=" + text.DesEncrypt());
					}
					else
					{
						StringBuilder stringBuilder2 = stringBuilder;
						string arg = str2;
						string arg2 = showUrl + "?id=" + text.DesEncrypt();
						int num2 = ++num;
						stringBuilder2.AppendFormat("<div{0}><a target=\"_blank\" href=\"{1}\" class=\"blue1\">{2}</a></div>", arg, arg2, num2.ToString() + "、" + Path.GetFileName(text));
					}
				}
			}
			stringBuilder.Append("<div style=\"clear:both;\"></div>");
			return stringBuilder.ToString();
		}

		public static bool IsImage(string file)
		{
			string extension = Path.GetExtension(file);
			if (extension.IsNullOrEmpty())
			{
				return false;
			}
			if (!(extension.ToLower() == ".jpg") && !(extension.ToLower() == ".jpeg") && !(extension.ToLower() == ".png") && !(extension.ToLower() == ".gif"))
			{
				return extension.ToLower() == ".bmp";
			}
			return true;
		}
	}
}
