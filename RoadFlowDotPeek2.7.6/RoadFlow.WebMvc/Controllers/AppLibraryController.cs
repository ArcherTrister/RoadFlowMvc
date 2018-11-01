// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.AppLibraryController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class AppLibraryController : MyController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tree()
        {
            return View();
        }

        public ActionResult List()
        {
            string text = base.Request.QueryString["appid"];
            string text2 = base.Request.QueryString["tabid"];
            string text3 = base.Request.QueryString["typeid"];
            string text4 = string.Format("&appid={0}&tabid={1}&typeid={2}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"], base.Request.QueryString["typeid"]);
            base.ViewBag.Query1 = text4;
            base.ViewBag.TypeID = text3;
            base.ViewBag.AppID = text;
            base.ViewBag.TabID = text2;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Delete()
        {
            RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
            string text = base.Request.Form["ids"];
            StringBuilder stringBuilder = new StringBuilder();
            using (TransactionScope transactionScope = new TransactionScope())
            {
                string[] array = text.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    Guid id = default(Guid);
                    if (MyExtensions.IsGuid(array[i], out id))
                    {
                        RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary.Get(id);
                        if (appLibrary2 != null)
                        {
                            stringBuilder.Append(MyExtensions.Serialize(appLibrary2));
                            appLibrary.Delete(id);
                            new RoadFlow.Platform.AppLibraryButtons1().DeleteByAppID(id);
                            new RoadFlow.Platform.AppLibrarySubPages().DeleteByAppID(id);
                        }
                    }
                }
                new RoadFlow.Platform.Menu().ClearAllDataTableCache();
                new RoadFlow.Platform.AppLibraryButtons1().ClearCache();
                new RoadFlow.Platform.AppLibrarySubPages().ClearCache();
                RoadFlow.Platform.Log.Add("删除了一批应用程序库", stringBuilder.ToString(), RoadFlow.Platform.Log.Types.菜单权限);
                transactionScope.Complete();
            }
            return "删除成功!";
        }

        public ActionResult Edit()
        {
            return Edit(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            string text = base.Request.QueryString["id"];
            string value = base.Request.QueryString["typeid"];
            RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
            RoadFlow.Data.Model.AppLibrary appLibrary2 = null;
            if (MyExtensions.IsGuid(text))
            {
                appLibrary2 = appLibrary.Get(MyExtensions.ToGuid(text));
            }
            bool flag = !MyExtensions.IsGuid(text);
            string oldXML = string.Empty;
            if (appLibrary2 == null)
            {
                appLibrary2 = new RoadFlow.Data.Model.AppLibrary();
                appLibrary2.ID = Guid.NewGuid();
                base.ViewBag.TypeOptions = new RoadFlow.Platform.AppLibrary().GetTypeOptions(value);
                base.ViewBag.OpenOptions = new RoadFlow.Platform.Dictionary().GetOptionsByCode("appopenmodel");
            }
            else
            {
                oldXML = MyExtensions.Serialize((object)appLibrary2);
                base.ViewBag.TypeOptions = new RoadFlow.Platform.AppLibrary().GetTypeOptions(appLibrary2.Type.ToString());
                base.ViewBag.OpenOptions = new RoadFlow.Platform.Dictionary().GetOptionsByCode("appopenmodel", RoadFlow.Platform.Dictionary.OptionValueField.Value, appLibrary2.OpenMode.ToString());
            }
            if (collection != null)
            {
                string title = collection["title"];
                string text2 = collection["address"];
                string text3 = collection["openModel"];
                string text4 = collection["width"];
                string text5 = collection["height"];
                string @params = collection["Params"];
                string note = collection["Note"];
                string text6 = collection["Ico"];
                string text7 = collection["IcoColor"];
                value = collection["type"];
                appLibrary2.Address = text2.Trim();
                appLibrary2.Height = MyExtensions.ToIntOrNull(text5);
                appLibrary2.Note = note;
                appLibrary2.OpenMode = MyExtensions.ToInt(text3);
                appLibrary2.Params = @params;
                appLibrary2.Title = title;
                appLibrary2.Type = MyExtensions.ToGuid(value);
                appLibrary2.Width = MyExtensions.ToIntOrNull(text4);
                if (!MyExtensions.IsNullOrEmpty(text6))
                {
                    appLibrary2.Ico = text6;
                }
                else
                {
                    appLibrary2.Ico = null;
                }
                if (!MyExtensions.IsNullOrEmpty(text7))
                {
                    appLibrary2.Color = text7.Trim();
                }
                else
                {
                    appLibrary2.Color = null;
                }
                string text8 = base.Request.QueryString["pagesize"];
                string text9 = base.Request.QueryString["pagenumber"];
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    if (flag)
                    {
                        appLibrary.Add(appLibrary2);
                        RoadFlow.Platform.Log.Add("添加了应用程序库", MyExtensions.Serialize((object)appLibrary2), RoadFlow.Platform.Log.Types.菜单权限);
                        base.ViewBag.Script = "alert('添加成功!');new RoadUI.Window().reloadOpener(undefined,undefined,\"query('" + text8 + "','" + text9 + "')\");new RoadUI.Window().close();";
                    }
                    else
                    {
                        appLibrary.Update(appLibrary2);
                        RoadFlow.Platform.Log.Add("修改了应用程序库", "", RoadFlow.Platform.Log.Types.菜单权限, oldXML, MyExtensions.Serialize((object)appLibrary2));
                        base.ViewBag.Script = "alert('修改成功!');new RoadUI.Window().reloadOpener(undefined,undefined,\"query('" + text8 + "','" + text9 + "')\");new RoadUI.Window().close();";
                    }
                    RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons = new RoadFlow.Platform.AppLibraryButtons1();
                    string obj = base.Request.Form["buttonindex"] ?? "";
                    List<RoadFlow.Data.Model.AppLibraryButtons1> allByAppID = appLibraryButtons.GetAllByAppID(appLibrary2.ID);
                    List<RoadFlow.Data.Model.AppLibraryButtons1> list = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
                    string[] array = obj.Split(',');
                    foreach (string index in array)
                    {
                        string text10 = base.Request.Form["button_" + index];
                        string text11 = base.Request.Form["buttonname_" + index];
                        string text12 = base.Request.Form["buttonevents_" + index];
                        string ico = base.Request.Form["buttonico_" + index];
                        string text13 = base.Request.Form["showtype_" + index];
                        string text14 = base.Request.Form["buttonsort_" + index];
                        if (!MyExtensions.IsNullOrEmpty(text11) && !MyExtensions.IsNullOrEmpty(text12))
                        {
                            RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons2 = allByAppID.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == MyExtensions.ToGuid(index));
                            bool flag2 = false;
                            if (appLibraryButtons2 == null)
                            {
                                flag2 = true;
                                appLibraryButtons2 = new RoadFlow.Data.Model.AppLibraryButtons1();
                                appLibraryButtons2.ID = Guid.NewGuid();
                            }
                            else
                            {
                                list.Add(appLibraryButtons2);
                            }
                            appLibraryButtons2.AppLibraryID = appLibrary2.ID;
                            if (MyExtensions.IsGuid(text10))
                            {
                                appLibraryButtons2.ButtonID = MyExtensions.ToGuid(text10);
                            }
                            appLibraryButtons2.Events = text12;
                            appLibraryButtons2.Ico = ico;
                            appLibraryButtons2.Name = MyExtensions.Trim1(text11);
                            appLibraryButtons2.Sort = MyExtensions.ToInt(text14, 0);
                            appLibraryButtons2.ShowType = MyExtensions.ToInt(text13, 0);
                            appLibraryButtons2.Type = 0;
                            if (flag2)
                            {
                                appLibraryButtons.Add(appLibraryButtons2);
                            }
                            else
                            {
                                appLibraryButtons.Update(appLibraryButtons2);
                            }
                        }
                    }
                    foreach (RoadFlow.Data.Model.AppLibraryButtons1 item in allByAppID)
                    {
                        if (list.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == item.ID) == null)
                        {
                            appLibraryButtons.Delete(item.ID);
                        }
                    }
                    transactionScope.Complete();
                    appLibraryButtons.ClearCache();
                }
                new RoadFlow.Platform.Menu().ClearAllDataTableCache();
                new RoadFlow.Platform.WorkFlow().ClearStartFlowsCache();
                appLibrary.ClearCache();
            }
            return View(appLibrary2);
        }

        public ActionResult SubPages()
        {
            return View();
        }

        public ActionResult SubPageEdit()
        {
            return SubPageEdit(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubPageEdit(FormCollection collection)
        {
            RoadFlow.Platform.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Platform.AppLibrarySubPages();
            RoadFlow.Data.Model.AppLibrarySubPages appLibrarySubPages2 = null;
            string text = base.Request.QueryString["subid"];
            if (MyExtensions.IsGuid(text))
            {
                appLibrarySubPages2 = appLibrarySubPages.Get(MyExtensions.ToGuid(text));
            }
            if (collection != null)
            {
                string text2 = base.Request.Form["Title"];
                string text3 = base.Request.Form["Address"];
                bool flag = false;
                if (appLibrarySubPages2 == null)
                {
                    appLibrarySubPages2 = new RoadFlow.Data.Model.AppLibrarySubPages();
                    flag = true;
                    appLibrarySubPages2.ID = Guid.NewGuid();
                    appLibrarySubPages2.AppLibraryID = MyExtensions.ToGuid(base.Request.QueryString["id"]);
                }
                appLibrarySubPages2.Name = MyExtensions.Trim1(text2);
                appLibrarySubPages2.Address = MyExtensions.Trim1(text3);
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    if (flag)
                    {
                        appLibrarySubPages.Add(appLibrarySubPages2);
                        RoadFlow.Platform.Log.Add("添加了子页面", MyExtensions.Serialize((object)appLibrarySubPages2), RoadFlow.Platform.Log.Types.菜单权限);
                        base.ViewBag.Script = "alert('添加成功!');window.location='SubPages" + base.Request.Url.Query + "';";
                    }
                    else
                    {
                        appLibrarySubPages.Update(appLibrarySubPages2);
                        RoadFlow.Platform.Log.Add("修改了子页面", MyExtensions.Serialize((object)appLibrarySubPages2), RoadFlow.Platform.Log.Types.菜单权限);
                        base.ViewBag.Script = "alert('保存成功!');window.location='SubPages" + base.Request.Url.Query + "';";
                    }
                    RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons = new RoadFlow.Platform.AppLibraryButtons1();
                    string obj = base.Request.Form["buttonindex"] ?? "";
                    List<RoadFlow.Data.Model.AppLibraryButtons1> allByAppID = appLibraryButtons.GetAllByAppID(appLibrarySubPages2.ID);
                    List<RoadFlow.Data.Model.AppLibraryButtons1> list = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
                    string[] array = obj.Split(',');
                    foreach (string index in array)
                    {
                        string text4 = base.Request.Form["button_" + index];
                        string text5 = base.Request.Form["buttonname_" + index];
                        string text6 = base.Request.Form["buttonevents_" + index];
                        string ico = base.Request.Form["buttonico_" + index];
                        string text7 = base.Request.Form["showtype_" + index];
                        string text8 = base.Request.Form["buttonsort_" + index];
                        if (!MyExtensions.IsNullOrEmpty(text5) && !MyExtensions.IsNullOrEmpty(text6))
                        {
                            RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons2 = allByAppID.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == MyExtensions.ToGuid(index));
                            bool flag2 = false;
                            if (appLibraryButtons2 == null)
                            {
                                flag2 = true;
                                appLibraryButtons2 = new RoadFlow.Data.Model.AppLibraryButtons1();
                                appLibraryButtons2.ID = Guid.NewGuid();
                            }
                            else
                            {
                                list.Add(appLibraryButtons2);
                            }
                            appLibraryButtons2.AppLibraryID = appLibrarySubPages2.ID;
                            if (MyExtensions.IsGuid(text4))
                            {
                                appLibraryButtons2.ButtonID = MyExtensions.ToGuid(text4);
                            }
                            appLibraryButtons2.Events = text6;
                            appLibraryButtons2.Ico = ico;
                            appLibraryButtons2.Name = MyExtensions.Trim1(text5);
                            appLibraryButtons2.Sort = MyExtensions.ToInt(text8, 0);
                            appLibraryButtons2.ShowType = MyExtensions.ToInt(text7, 0);
                            appLibraryButtons2.Type = 0;
                            if (flag2)
                            {
                                appLibraryButtons.Add(appLibraryButtons2);
                            }
                            else
                            {
                                appLibraryButtons.Update(appLibraryButtons2);
                            }
                        }
                    }
                    foreach (RoadFlow.Data.Model.AppLibraryButtons1 item in allByAppID)
                    {
                        if (list.Find((RoadFlow.Data.Model.AppLibraryButtons1 p) => p.ID == item.ID) == null)
                        {
                            appLibraryButtons.Delete(item.ID);
                        }
                    }
                    transactionScope.Complete();
                    appLibraryButtons.ClearCache();
                    appLibrarySubPages.ClearCache();
                }
            }
            if (appLibrarySubPages2 == null)
            {
                appLibrarySubPages2 = new RoadFlow.Data.Model.AppLibrarySubPages();
                appLibrarySubPages2.ID = Guid.Empty;
                appLibrarySubPages2.AppLibraryID = MyExtensions.ToGuid(base.Request.QueryString["id"]);
            }
            return View(appLibrarySubPages2);
        }

        public RedirectResult SubPageDelete()
        {
            string text = base.Request.Form["subpagesbox"] ?? "";
            RoadFlow.Platform.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Platform.AppLibrarySubPages();
            RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons = new RoadFlow.Platform.AppLibraryButtons1();
            using (TransactionScope transactionScope = new TransactionScope())
            {
                string[] array = text.Split(',');
                foreach (string text2 in array)
                {
                    if (MyExtensions.IsGuid(text2))
                    {
                        appLibrarySubPages.Delete(MyExtensions.ToGuid(text2));
                        appLibraryButtons.DeleteByAppID(MyExtensions.ToGuid(text2));
                    }
                }
                RoadFlow.Platform.Log.Add("删除了子页面", text, RoadFlow.Platform.Log.Types.菜单权限);
                transactionScope.Complete();
            }
            appLibrarySubPages.ClearCache();
            appLibraryButtons.ClearCache();
            return Redirect("SubPages" + base.Request.Url.Query);
        }

        [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
        public string GetApps()
        {
            string text = base.Request.Form["type"];
            string value = base.Request.Form["value"];
            return new RoadFlow.Platform.AppLibrary().GetAppsOptions(MyExtensions.ToGuid(text), value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAttribute(CheckApp = false)]
        public string Query()
        {
            string text = base.Request.Form["Title"];
            string text2 = base.Request.Form["Address"];
            string text3 = base.Request.Form["typeid"];
            string text4 = base.Request.Form["sidx"];
            string text5 = base.Request.Form["sord"];
            RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
            RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
            string type = MyExtensions.IsGuid(text3) ? appLibrary.GetAllChildsIDString(MyExtensions.ToGuid(text3)) : "";
            int pageSize = Tools.GetPageSize();
            int pageNumber = Tools.GetPageNumber();
            string order = (MyExtensions.IsNullOrEmpty(text4) ? "Title" : text4) + " " + (MyExtensions.IsNullOrEmpty(text5) ? "asc" : text5);
            long count;
            List<RoadFlow.Data.Model.AppLibrary> pagerData = appLibrary.GetPagerData(out count, pageSize, pageNumber, MyExtensions.Trim1(text), type, MyExtensions.Trim1(text2), order);
            JsonData jsonData = new JsonData();
            foreach (RoadFlow.Data.Model.AppLibrary item in pagerData)
            {
                string empty = string.Empty;
                empty = ((!MyExtensions.IsFontIco(item.Ico)) ? ("<img src=\"" + MyExtensions.Trim1(item.Ico) + "\" style=\"vertical-align:middle;\" />") : ("<i class=\"fa " + MyExtensions.Trim1(item.Ico) + "\" style=\"font-size:14px;vertical-align:middle;" + (MyExtensions.IsNullOrEmpty(item.Color) ? "" : ("color:" + item.Color + ";")) + "\"></i>"));
                JsonData jsonData2 = new JsonData();
                jsonData2["id"] = item.ID.ToString();
                jsonData2["Title"] = empty + "<span style=\"vertical-align:middle;margin-left:4px;\">" + item.Title + "</span>";
                jsonData2["Address"] = item.Address;
                jsonData2["TypeTitle"] = dictionary.GetTitle(item.Type);
                jsonData2["Opation"] = "<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"edit('" + item.ID.ToString() + "');return false;\" style=\"margin-right:6px;\">编辑</a><a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"editsubpage('" + item.ID.ToString() + "');return false;\">子页面</a>";
                jsonData.Add(jsonData2);
            }
            return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
        }
    }
}
