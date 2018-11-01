using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Controllers
{
	public class DictController : MyController
	{
		public ActionResult Index()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public string Tree1()
		{
			string msg;
			if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			string text = base.Request.QueryString["root"];
			bool flag2 = "1" == base.Request.QueryString["ischild"];
			Guid test = Guid.Empty;
			if (!text.IsNullOrEmpty() && !text.IsGuid(out test))
			{
				RoadFlow.Data.Model.Dictionary byCode = dictionary.GetByCode(text);
				if (byCode != null)
				{
					test = byCode.ID;
				}
			}
			RoadFlow.Data.Model.Dictionary dictionary2 = (test != Guid.Empty) ? dictionary.Get(test) : dictionary.GetRoot();
			bool flag = dictionary.HasChilds(dictionary2.ID);
			StringBuilder stringBuilder = new StringBuilder("[", 1000);
			stringBuilder.Append("{");
			stringBuilder.AppendFormat("\"id\":\"{0}\",", dictionary2.ID);
			stringBuilder.AppendFormat("\"parentID\":\"{0}\",", dictionary2.ParentID);
			stringBuilder.AppendFormat("\"title\":\"{0}\",", dictionary2.Title);
			stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? "0" : "2");
			stringBuilder.AppendFormat("\"ico\":\"{0}\",", base.Url.Content("~/images/ico/role.gif"));
			stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? "1" : "0");
			stringBuilder.Append("\"childs\":[");
			List<RoadFlow.Data.Model.Dictionary> childs = dictionary.GetChilds(dictionary2.ID);
			int num = 0;
			int count = childs.Count;
			foreach (RoadFlow.Data.Model.Dictionary item in childs)
			{
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", item.ID);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", item.ParentID);
				stringBuilder.AppendFormat("\"title\":\"{0}\",", item.Title);
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", dictionary.HasChilds(item.ID) ? "1" : "0");
				stringBuilder.Append("\"childs\":[");
				stringBuilder.Append("]");
				stringBuilder.Append("}");
				if (num++ < count - 1)
				{
					stringBuilder.Append(",");
				}
			}
			stringBuilder.Append("]");
			stringBuilder.Append("}");
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public string TreeRefresh()
		{
			string msg;
			if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			Guid test;
			if (!base.Request.QueryString["refreshid"].IsGuid(out test))
			{
				base.Response.Write("[]");
			}
			StringBuilder stringBuilder = new StringBuilder("[", 1000);
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			IOrderedEnumerable<RoadFlow.Data.Model.Dictionary> orderedEnumerable = from p in dictionary.GetChilds(test)
			orderby p.Sort
			select p;
			int num = 0;
			int num2 = orderedEnumerable.Count();
			foreach (RoadFlow.Data.Model.Dictionary item in orderedEnumerable)
			{
				bool flag = dictionary.HasChilds(item.ID);
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", item.ID);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", item.ParentID);
				stringBuilder.AppendFormat("\"title\":\"{0}\",", item.Title);
				stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? "1" : "2");
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? "1" : "0");
				stringBuilder.Append("\"childs\":[");
				stringBuilder.Append("]");
				stringBuilder.Append("}");
				if (num++ < num2 - 1)
				{
					stringBuilder.Append(",");
				}
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Tree()
		{
			return View();
		}

		public ActionResult Body()
		{
			return Body(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Body(FormCollection collection)
		{
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			RoadFlow.Data.Model.Dictionary dictionary2 = null;
			string str = base.Request.QueryString["id"];
			if (str.IsGuid())
			{
				dictionary2 = dictionary.Get(str.ToGuid());
			}
			if (dictionary2 == null)
			{
				dictionary2 = dictionary.GetRoot();
			}
			if (collection != null)
			{
				string text = (dictionary2.ParentID == Guid.Empty) ? dictionary2.ID.ToString() : dictionary2.ParentID.ToString();
				if (!base.Request.Form["Delete"].IsNullOrEmpty())
				{
					int num = dictionary.DeleteAndAllChilds(dictionary2.ID);
					dictionary.RefreshCache();
					RoadFlow.Platform.Log.Add("删除了数据字典及其下级共" + num.ToString() + "项", dictionary2.Serialize(), RoadFlow.Platform.Log.Types.数据字典);
					base.ViewBag.Script = "alert('删除成功!');parent.frames[0].reLoad('" + text + "');window.location='Body?id=" + dictionary2.ParentID.ToString() + "&appid=" + base.Request.QueryString["appid"] + "';";
					return View(dictionary2);
				}
				string text2 = base.Request.Form["Title"];
				string text3 = base.Request.Form["Code"];
				string text4 = base.Request.Form["Values"];
				string text5 = base.Request.Form["Note"];
				string text6 = base.Request.Form["Other"];
				string oldXML = dictionary2.Serialize();
				dictionary2.Code = (text3.IsNullOrEmpty() ? null : text3.Trim());
				dictionary2.Note = (text5.IsNullOrEmpty() ? null : text5.Trim());
				dictionary2.Other = (text6.IsNullOrEmpty() ? null : text6.Trim());
				dictionary2.Title = text2.Trim();
				dictionary2.Value = (text4.IsNullOrEmpty() ? null : text4.Trim());
				dictionary.Update(dictionary2);
				dictionary.RefreshCache();
				RoadFlow.Platform.Log.Add("修改了数据字典项", "", RoadFlow.Platform.Log.Types.数据字典, oldXML, dictionary2.Serialize());
				base.ViewBag.Script = "alert('保存成功!');parent.frames[0].reLoad('" + text + "');";
			}
			return View(dictionary2);
		}

		[MyAttribute(CheckApp = false)]
		public string CheckCode()
		{
			string code = base.Request.Form["value"];
			string id = base.Request["id"];
			if (!new RoadFlow.Platform.Dictionary().HasCode(code, id))
			{
				return "1";
			}
			return "唯一代码重复";
		}

		public ActionResult Add()
		{
			return add1(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Add(FormCollection collection)
		{
			return add1(collection);
		}

		public ActionResult add1(FormCollection collection)
		{
			RoadFlow.Data.Model.Dictionary dictionary = new RoadFlow.Data.Model.Dictionary();
			RoadFlow.Platform.Dictionary dictionary2 = new RoadFlow.Platform.Dictionary();
			string text = base.Request.QueryString["id"];
			if (!text.IsGuid())
			{
				RoadFlow.Data.Model.Dictionary root = dictionary2.GetRoot();
				text = ((root != null) ? root.ID.ToString() : "");
			}
			if (!text.IsGuid())
			{
				throw new Exception("未找到父级");
			}
			if (collection != null)
			{
				string text2 = base.Request.Form["Title"];
				string text3 = base.Request.Form["Code"];
				string text4 = base.Request.Form["Values"];
				string text5 = base.Request.Form["Note"];
				string text6 = base.Request.Form["Other"];
				dictionary.ID = Guid.NewGuid();
				dictionary.Code = (text3.IsNullOrEmpty() ? null : text3.Trim());
				dictionary.Note = (text5.IsNullOrEmpty() ? null : text5.Trim());
				dictionary.Other = (text6.IsNullOrEmpty() ? null : text6.Trim());
				dictionary.ParentID = text.ToGuid();
				dictionary.Sort = dictionary2.GetMaxSort(text.ToGuid());
				dictionary.Title = text2.Trim();
				dictionary.Value = (text4.IsNullOrEmpty() ? null : text4.Trim());
				dictionary2.Add(dictionary);
				dictionary2.RefreshCache();
				RoadFlow.Platform.Log.Add("添加了数据字典项", dictionary.Serialize(), RoadFlow.Platform.Log.Types.数据字典);
				base.ViewBag.Script = "alert('添加成功!');parent.frames[0].reLoad('" + text + "');";
			}
			return View(dictionary);
		}

		public ActionResult Sort()
		{
			return Sort(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Sort(FormCollection collection)
		{
			RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
			string text = base.Request.QueryString["id"];
			string text2 = "";
			List<RoadFlow.Data.Model.Dictionary> model = new List<RoadFlow.Data.Model.Dictionary>();
			Guid test;
			if (text.IsGuid(out test))
			{
				RoadFlow.Data.Model.Dictionary dictionary2 = dictionary.Get(test);
				if (dictionary2 != null)
				{
					model = dictionary.GetChilds(dictionary2.ParentID);
					text2 = dictionary2.ParentID.ToString();
				}
			}
			if (collection != null)
			{
				string text3 = base.Request.Form["sort"];
				if (text3.IsNullOrEmpty())
				{
					return View(model);
				}
				string[] array = text3.Split(',');
				int num = 1;
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					Guid test2;
					if (array2[i].IsGuid(out test2))
					{
						dictionary.UpdateSort(test2, num++);
					}
				}
				dictionary.RefreshCache();
				RoadFlow.Platform.Log.Add("保存了数据字典排序", "保存了ID为：" + text + "的同级排序", RoadFlow.Platform.Log.Types.数据字典);
				base.ViewBag.Script = "parent.frames[0].reLoad('" + text2 + "');";
				model = dictionary.GetChilds(text2.ToGuid());
			}
			return View(model);
		}
	}
}
