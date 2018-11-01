<%@ WebHandler Language="C#" Class="UEditorHandler" %>

using System;
using System.Web;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

public class UEditorHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        UEHandler action = null;
        switch (context.Request["action"])
        {
            case "config":
                action = new UEConfigHandler(context);
                break;
            case "uploadimage":
                action = new UEUploadHandler(context, new UEUploadConfig()
                {
                    AllowExtensions = UEConfig.GetStringList("imageAllowFiles"),
                    PathFormat = UEConfig.GetString("imagePathFormat"),
                    SizeLimit = UEConfig.GetInt("imageMaxSize"),
                    UploadFieldName = UEConfig.GetString("imageFieldName")
                });
                break;
            case "uploadscrawl":
                action = new UEUploadHandler(context, new UEUploadConfig()
                {
                    AllowExtensions = new string[] { ".png" },
                    PathFormat = UEConfig.GetString("scrawlPathFormat"),
                    SizeLimit = UEConfig.GetInt("scrawlMaxSize"),
                    UploadFieldName = UEConfig.GetString("scrawlFieldName"),
                    Base64 = true,
                    Base64Filename = "scrawl.png"
                });
                break;
            case "uploadvideo":
                action = new UEUploadHandler(context, new UEUploadConfig()
                {
                    AllowExtensions = UEConfig.GetStringList("videoAllowFiles"),
                    PathFormat = UEConfig.GetString("videoPathFormat"),
                    SizeLimit = UEConfig.GetInt("videoMaxSize"),
                    UploadFieldName = UEConfig.GetString("videoFieldName")
                });
                break;
            case "uploadfile":
                action = new UEUploadHandler(context, new UEUploadConfig()
                {
                    AllowExtensions = UEConfig.GetStringList("fileAllowFiles"),
                    PathFormat = UEConfig.GetString("filePathFormat"),
                    SizeLimit = UEConfig.GetInt("fileMaxSize"),
                    UploadFieldName = UEConfig.GetString("fileFieldName")
                });
                break;
            case "listimage":
                action = new UEListFileManager(context, UEConfig.GetString("imageManagerListPath"), UEConfig.GetStringList("imageManagerAllowFiles"));
                break;
            case "listfile":
                action = new UEListFileManager(context, UEConfig.GetString("fileManagerListPath"), UEConfig.GetStringList("fileManagerAllowFiles"));
                break;
            case "catchimage":
                action = new UECrawlerHandler(context);
                break;
            default:
                action = new UENotSupportedHandler(context);
                break;
        }
        action.Process();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}