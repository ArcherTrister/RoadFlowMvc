using RoadFlow.Platform;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
	public class WorkFlowSignController : MyController
	{
		public ActionResult Index()
		{
			if (base.Request.Files.Count > 0 && base.Request.Files[0].ContentLength > 0)
			{
				HttpPostedFileBase httpPostedFileBase = base.Request.Files[0];
				string extension = Path.GetExtension(httpPostedFileBase.FileName);
				if (extension.IsNullOrEmpty() || (extension.ToLower() != ".gif" && extension.ToLower() != ".jpg" && extension.ToLower() != ".png"))
				{
					base.Response.Write("<script>alert('只能上传gif,jpg,png类型的图片文件!'); window.location = window.location;</script>");
					base.Response.End();
					return null;
				}
				string text = base.Server.MapPath(base.Url.Content("~/Content/UserSigns/")) + Users.CurrentUserID + ".gif";
				httpPostedFileBase.SaveAs(text);
				Log.Add("修改了签名", text, Log.Types.流程相关);
				base.ViewBag.Script = "alert('上传成功!'); window.location = window.location;";
			}
			if (!base.Request.Form["reset"].IsNullOrEmpty())
			{
				string text2 = base.Server.MapPath(base.Url.Content("~/Content/UserSigns/")) + Users.CurrentUserID + ".gif";
				if (System.IO.File.Exists(text2))
				{
					System.IO.File.Delete(text2);
					Log.Add("恢复了签名", text2, Log.Types.流程相关);
				}
				base.ViewBag.Script = "alert('已恢复为默认签名!'); window.location = window.location;";
			}
			return View();
		}
	}
}
