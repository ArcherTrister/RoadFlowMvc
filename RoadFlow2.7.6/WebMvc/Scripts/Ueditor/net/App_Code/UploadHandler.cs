// Decompiled with JetBrains decompiler
// Type: UEUploadHandler
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class UEUploadHandler : UEHandler
{
  public UEUploadConfig UploadConfig { get; private set; }

  public UEUploadResult Result { get; private set; }

  public UEUploadHandler(HttpContext context, UEUploadConfig config)
    : base(context)
  {
    this.UploadConfig = config;
    this.Result = new UEUploadResult()
    {
      State = UEUploadState.Unknown
    };
  }

  public override void Process()
  {
    string str;
    byte[] numArray;
    if (this.UploadConfig.Base64)
    {
      str = this.UploadConfig.Base64Filename;
      numArray = Convert.FromBase64String(this.Request[this.UploadConfig.UploadFieldName]);
    }
    else
    {
      HttpPostedFile file = this.Request.Files[this.UploadConfig.UploadFieldName];
      str = file.FileName;
      if (!this.CheckFileType(str))
      {
        this.Result.State = UEUploadState.TypeNotAllow;
        this.WriteResult();
        return;
      }
      if (!this.CheckFileSize(file.ContentLength))
      {
        this.Result.State = UEUploadState.SizeLimitExceed;
        this.WriteResult();
        return;
      }
      numArray = new byte[file.ContentLength];
      try
      {
        file.InputStream.Read(numArray, 0, file.ContentLength);
      }
      catch (Exception ex)
      {
        this.Result.State = UEUploadState.NetworkError;
        this.WriteResult();
      }
    }
    this.Result.OriginFileName = str;
    string path1 = UEPathFormatter.Format(str, this.UploadConfig.PathFormat);
    string path2 = this.Server.MapPath(path1);
    try
    {
      if (!Directory.Exists(Path.GetDirectoryName(path2)))
        Directory.CreateDirectory(Path.GetDirectoryName(path2));
      File.WriteAllBytes(path2, numArray);
      this.Result.Url = path1;
      this.Result.State = UEUploadState.Success;
    }
    catch (Exception ex)
    {
      this.Result.State = UEUploadState.FileAccessError;
      this.Result.ErrorMessage = ex.Message;
    }
    finally
    {
      this.WriteResult();
    }
  }

  private void WriteResult()
  {
    this.WriteJson((object) new
    {
      state = this.GetStateMessage(this.Result.State),
      url = this.Result.Url,
      title = this.Result.OriginFileName,
      original = this.Result.OriginFileName,
      error = this.Result.ErrorMessage
    });
  }

  private string GetStateMessage(UEUploadState state)
  {
    switch (state)
    {
      case UEUploadState.NetworkError:
        return "网络错误";
      case UEUploadState.FileAccessError:
        return "文件访问出错，请检查写入权限";
      case UEUploadState.TypeNotAllow:
        return "不允许的文件格式";
      case UEUploadState.SizeLimitExceed:
        return "文件大小超出服务器限制";
      case UEUploadState.Success:
        return "SUCCESS";
      default:
        return "未知错误";
    }
  }

  private bool CheckFileType(string filename)
  {
    return ((IEnumerable<string>) this.UploadConfig.AllowExtensions).Select<string, string>((Func<string, string>) (x => x.ToLower())).Contains<string>(Path.GetExtension(filename).ToLower());
  }

  private bool CheckFileSize(int size)
  {
    return size < this.UploadConfig.SizeLimit;
  }
}
