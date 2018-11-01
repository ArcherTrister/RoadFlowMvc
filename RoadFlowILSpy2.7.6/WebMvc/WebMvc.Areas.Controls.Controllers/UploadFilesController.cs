using RoadFlow.Cache.IO;
using RoadFlow.Utility;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Areas.Controls.Controllers
{
	public class UploadFilesController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Index_App()
		{
			return View();
		}

		public string Upload()
		{
			base.Response.ContentType = "text/plain";
			string text = base.Request.Form["filetype"];
			if (!WebMvc.Common.Tools.CheckLogin(false))
			{
				return "您不能上传文件";
			}
			HttpPostedFileBase httpPostedFileBase = base.Request.Files["Filedata"];
			if (text.IsNullOrEmpty())
			{
				if (!RoadFlow.Utility.Config.UploadFileType.Contains(Path.GetExtension(httpPostedFileBase.FileName).TrimStart('.'), StringComparison.CurrentCultureIgnoreCase))
				{
					return "您上传的文件类型不被允许";
				}
			}
			else if (!text.Contains(Path.GetExtension(httpPostedFileBase.FileName).TrimStart('.'), StringComparison.CurrentCultureIgnoreCase))
			{
				return "您上传的文件类型不被允许";
			}
			string path;
			string text2 = base.Server.MapPath(getFilePath(out path));
			if (httpPostedFileBase != null)
			{
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				string fileName = getFileName(text2, httpPostedFileBase.FileName);
				string filename = text2 + fileName;
				try
				{
					int contentLength = httpPostedFileBase.ContentLength;
					httpPostedFileBase.SaveAs(filename);
					return "1|" + path + fileName + "|" + (contentLength / 1000).ToString("###,###") + "|" + fileName;
				}
				catch
				{
					return "上传文件发生了错误";
				}
			}
			return "上传文件为空";
		}

		private string getFileName(string filePath, string fileName)
		{
			while (System.IO.File.Exists(filePath + fileName))
			{
				fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + RoadFlow.Utility.Tools.GetRandomString() + Path.GetExtension(fileName);
			}
			return fileName;
		}

		private string getFilePath(out string path1)
		{
			DateTime now = DateTimeNew.Now;
			path1 = base.Url.Content("~/Content/UploadFiles/" + now.ToString("yyyyMM") + "/" + now.ToString("dd") + "/");
			return path1;
		}

		public string Delete()
		{
			object obj = base.Request.QueryString["str1"];
			string text2 = base.Request.QueryString["str2"];
			if (obj == null)
			{
				obj = "";
			}
			Opation.Get((string)obj);
			if (!WebMvc.Common.Tools.CheckLogin(false))
			{
				return "var json = {\"success\":0,\"message\":\"您不能删除文件\"}";
			}
			string text = base.Request.QueryString["file"];
			if (!text.IsNullOrEmpty())
			{
				try
				{
					System.IO.File.Delete(base.Server.MapPath(Path.Combine(base.Url.Content("~/Content/Controls/UploadFiles/"), text)));
					return "var json = {\"success\":1,\"message\":\"\"}";
				}
				catch (Exception ex)
				{
					return "var json = {\"success\":0,\"message\":\"" + ex.Message + "\"}";
				}
			}
			return "";
		}
	}
}
