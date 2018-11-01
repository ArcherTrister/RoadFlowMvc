// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.WeiXin.Controllers.DocumentsController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Platform;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
    public class DocumentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return Search(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(FormCollection coll)
        {
            string text = string.Empty;
            if (coll != null)
            {
                text = base.Request.Form["searchkey"];
            }
            base.ViewBag.searchText = text;
            return View();
        }

        public ActionResult List()
        {
            return List(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult List(FormCollection coll)
        {
            string text = string.Empty;
            if (coll != null)
            {
                text = base.Request.Form["searchkey"];
            }
            base.ViewBag.searchText = text;
            return View();
        }

        public string GetDocs()
        {
            string text = base.Request.QueryString["pagenumber"];
            string text2 = base.Request.QueryString["pagesize"];
            string title = base.Request.QueryString["SearchTitle"];
            string dirID = base.Request.QueryString["dirid"];
            Guid currentUserID = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
            long count;
            DataTable list = new Documents().GetList(out count, MyExtensions.ToInt(text2), MyExtensions.ToInt(text), dirID, currentUserID.ToString(), title);
            JsonData jsonData = new JsonData();
            if (list.Rows.Count == 0)
            {
                return "[]";
            }
            foreach (DataRow row in list.Rows)
            {
                JsonData jsonData2 = new JsonData();
                jsonData2["id"] = row["ID"].ToString();
                jsonData2["title"] = row["Title"].ToString();
                jsonData2["writetime"] = MyExtensions.ToDateTimeString(MyExtensions.ToDateTime(row["WriteTime"].ToString()));
                jsonData2["writeuser"] = row["WriteUserName"].ToString();
                jsonData.Add(jsonData2);
            }
            return jsonData.ToJson();
        }
    }
}
