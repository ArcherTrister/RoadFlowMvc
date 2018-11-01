using System;
using System.IO;
using System.Net;
using System.Web;

public class UECrawler
{
	public string SourceUrl
	{
		get;
		set;
	}

	public string ServerUrl
	{
		get;
		set;
	}

	public string State
	{
		get;
		set;
	}

	private HttpServerUtility Server
	{
		get;
		set;
	}

	public UECrawler(string sourceUrl, HttpServerUtility server)
	{
		SourceUrl = sourceUrl;
		Server = server;
	}

	public UECrawler Fetch()
	{
		using (HttpWebResponse httpWebResponse = (WebRequest.Create(SourceUrl) as HttpWebRequest).GetResponse() as HttpWebResponse)
		{
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				State = "Url returns " + httpWebResponse.StatusCode + ", " + httpWebResponse.StatusDescription;
				return this;
			}
			if (httpWebResponse.ContentType.IndexOf("image") == -1)
			{
				State = "Url is not an image";
				return this;
			}
			ServerUrl = UEPathFormatter.Format(Path.GetFileName(SourceUrl), UEConfig.GetString("catcherPathFormat"));
			string path = Server.MapPath(ServerUrl);
			if (!Directory.Exists(Path.GetDirectoryName(path)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));
			}
			try
			{
				BinaryReader binaryReader = new BinaryReader(httpWebResponse.GetResponseStream());
				byte[] bytes;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					byte[] array = new byte[4096];
					int count;
					while ((count = binaryReader.Read(array, 0, array.Length)) != 0)
					{
						memoryStream.Write(array, 0, count);
					}
					bytes = memoryStream.ToArray();
				}
				File.WriteAllBytes(path, bytes);
				State = "SUCCESS";
			}
			catch (Exception ex)
			{
				State = "抓取错误：" + ex.Message;
			}
			return this;
		}
	}
}
