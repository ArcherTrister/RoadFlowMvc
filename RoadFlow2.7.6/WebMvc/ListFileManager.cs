using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class ListFileManager : Handler
{
	private enum ResultState
	{
		Success,
		InvalidParam,
		AuthorizError,
		IOError,
		PathNotFound
	}

	private int Start;

	private int Size;

	private int Total;

	private ResultState State;

	private string PathToList;

	private string[] FileList;

	private string[] SearchExtensions;

	public ListFileManager(HttpContext context, string pathToList, string[] searchExtensions)
		: base(context)
	{
		SearchExtensions = (from x in searchExtensions
		select x.ToLower()).ToArray();
		PathToList = pathToList;
	}

	public override void Process()
	{
		try
		{
			Start = ((!string.IsNullOrEmpty(base.Request["start"])) ? Convert.ToInt32(base.Request["start"]) : 0);
			Size = (string.IsNullOrEmpty(base.Request["size"]) ? Config.GetInt("imageManagerListSize") : Convert.ToInt32(base.Request["size"]));
		}
		catch (FormatException)
		{
			State = ResultState.InvalidParam;
			WriteResult();
			return;
		}
		List<string> list = new List<string>();
		try
		{
			string localPath = base.Server.MapPath(PathToList);
			list.AddRange(from x in Directory.GetFiles(localPath, "*", SearchOption.AllDirectories)
			where SearchExtensions.Contains(Path.GetExtension(x).ToLower())
			select PathToList + x.Substring(localPath.Length).Replace("\\", "/"));
			Total = list.Count;
			FileList = (from x in list
			orderby x
			select x).Skip(Start).Take(Size).ToArray();
		}
		catch (UnauthorizedAccessException)
		{
			State = ResultState.AuthorizError;
		}
		catch (DirectoryNotFoundException)
		{
			State = ResultState.PathNotFound;
		}
		catch (IOException)
		{
			State = ResultState.IOError;
		}
		finally
		{
			WriteResult();
		}
	}

	private void WriteResult()
	{
		WriteJson(new
		{
			state = GetStateString(),
			list = ((FileList == null) ? null : (from x in FileList
			select new
			{
				url = x
			})),
			start = Start,
			size = Size,
			total = Total
		});
	}

	private string GetStateString()
	{
		switch (State)
		{
		case ResultState.Success:
			return "SUCCESS";
		case ResultState.InvalidParam:
			return "参数不正确";
		case ResultState.PathNotFound:
			return "路径不存在";
		case ResultState.AuthorizError:
			return "文件系统权限不足";
		case ResultState.IOError:
			return "文件系统读取错误";
		default:
			return "未知错误";
		}
	}
}
