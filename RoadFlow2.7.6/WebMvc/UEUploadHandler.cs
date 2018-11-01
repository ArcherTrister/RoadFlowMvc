using System;
using System.IO;
using System.Linq;
using System.Web;

public class UEUploadHandler : UEHandler
{
	public UEUploadConfig UploadConfig
	{
		get;
		private set;
	}

	public UEUploadResult Result
	{
		get;
		private set;
	}

	public UEUploadHandler(HttpContext context, UEUploadConfig config)
		: base(context)
	{
		UploadConfig = config;
		Result = new UEUploadResult
		{
			State = UEUploadState.Unknown
		};
	}

	public override void Process()
	{
		byte[] array = null;
		string text = null;
		if (UploadConfig.Base64)
		{
			text = UploadConfig.Base64Filename;
			array = Convert.FromBase64String(base.Request[UploadConfig.UploadFieldName]);
		}
		else
		{
			HttpPostedFile httpPostedFile = base.Request.Files[UploadConfig.UploadFieldName];
			text = httpPostedFile.FileName;
			if (!CheckFileType(text))
			{
				Result.State = UEUploadState.TypeNotAllow;
				WriteResult();
				return;
			}
			if (!CheckFileSize(httpPostedFile.ContentLength))
			{
				Result.State = UEUploadState.SizeLimitExceed;
				WriteResult();
				return;
			}
			array = new byte[httpPostedFile.ContentLength];
			try
			{
				httpPostedFile.InputStream.Read(array, 0, httpPostedFile.ContentLength);
			}
			catch (Exception)
			{
				Result.State = UEUploadState.NetworkError;
				WriteResult();
			}
		}
		Result.OriginFileName = text;
		string text2 = UEPathFormatter.Format(text, UploadConfig.PathFormat);
		string path = base.Server.MapPath(text2);
		try
		{
			if (!Directory.Exists(Path.GetDirectoryName(path)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));
			}
			File.WriteAllBytes(path, array);
			Result.Url = text2;
			Result.State = UEUploadState.Success;
		}
		catch (Exception ex2)
		{
			Result.State = UEUploadState.FileAccessError;
			Result.ErrorMessage = ex2.Message;
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
			state = GetStateMessage(Result.State),
			url = Result.Url,
			title = Result.OriginFileName,
			original = Result.OriginFileName,
			error = Result.ErrorMessage
		});
	}

	private string GetStateMessage(UEUploadState state)
	{
		switch (state)
		{
		case UEUploadState.Success:
			return "SUCCESS";
		case UEUploadState.FileAccessError:
			return "文件访问出错，请检查写入权限";
		case UEUploadState.SizeLimitExceed:
			return "文件大小超出服务器限制";
		case UEUploadState.TypeNotAllow:
			return "不允许的文件格式";
		case UEUploadState.NetworkError:
			return "网络错误";
		default:
			return "未知错误";
		}
	}

	private bool CheckFileType(string filename)
	{
		string value = Path.GetExtension(filename).ToLower();
		return (from x in UploadConfig.AllowExtensions
		select x.ToLower()).Contains(value);
	}

	private bool CheckFileSize(int size)
	{
		return size < UploadConfig.SizeLimit;
	}
}
