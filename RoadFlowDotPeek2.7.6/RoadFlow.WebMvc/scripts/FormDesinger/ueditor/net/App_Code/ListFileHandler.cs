// Decompiled with JetBrains decompiler
// Type: ListFileManager
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class ListFileManager : Handler
{
  private int Start;
  private int Size;
  private int Total;
  private ListFileManager.ResultState State;
  private string PathToList;
  private string[] FileList;
  private string[] SearchExtensions;

  public ListFileManager(HttpContext context, string pathToList, string[] searchExtensions)
    : base(context)
  {
    this.SearchExtensions = ((IEnumerable<string>) searchExtensions).Select<string, string>((Func<string, string>) (x => x.ToLower())).ToArray<string>();
    this.PathToList = pathToList;
  }

  public override void Process()
  {
    try
    {
      this.Start = string.IsNullOrEmpty(this.Request["start"]) ? 0 : Convert.ToInt32(this.Request["start"]);
      this.Size = string.IsNullOrEmpty(this.Request["size"]) ? Config.GetInt("imageManagerListSize") : Convert.ToInt32(this.Request["size"]);
    }
    catch (FormatException ex)
    {
      this.State = ListFileManager.ResultState.InvalidParam;
      this.WriteResult();
      return;
    }
    List<string> source = new List<string>();
    try
    {
      string localPath = this.Server.MapPath(this.PathToList);
      source.AddRange(((IEnumerable<string>) Directory.GetFiles(localPath, "*", SearchOption.AllDirectories)).Where<string>((Func<string, bool>) (x => ((IEnumerable<string>) this.SearchExtensions).Contains<string>(Path.GetExtension(x).ToLower()))).Select<string, string>((Func<string, string>) (x => this.PathToList + x.Substring(localPath.Length).Replace("\\", "/"))));
      this.Total = source.Count;
      this.FileList = source.OrderBy<string, string>((Func<string, string>) (x => x)).Skip<string>(this.Start).Take<string>(this.Size).ToArray<string>();
    }
    catch (UnauthorizedAccessException ex)
    {
      this.State = ListFileManager.ResultState.AuthorizError;
    }
    catch (DirectoryNotFoundException ex)
    {
      this.State = ListFileManager.ResultState.PathNotFound;
    }
    catch (IOException ex)
    {
      this.State = ListFileManager.ResultState.IOError;
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
      state = this.GetStateString(),
      list = (this.FileList == null ? null : ((IEnumerable<string>) this.FileList).Select(x => new
      {
        url = x
      })),
      start = this.Start,
      size = this.Size,
      total = this.Total
    });
  }

  private string GetStateString()
  {
    switch (this.State)
    {
      case ListFileManager.ResultState.Success:
        return "SUCCESS";
      case ListFileManager.ResultState.InvalidParam:
        return "参数不正确";
      case ListFileManager.ResultState.AuthorizError:
        return "文件系统权限不足";
      case ListFileManager.ResultState.IOError:
        return "文件系统读取错误";
      case ListFileManager.ResultState.PathNotFound:
        return "路径不存在";
      default:
        return "未知错误";
    }
  }

  private enum ResultState
  {
    Success,
    InvalidParam,
    AuthorizError,
    IOError,
    PathNotFound,
  }
}
