using System.Text;

namespace RoadFlow.Utility
{
	public class HttpConfig
	{
		public string Referer
		{
			get;
			set;
		}

		public string ContentType
		{
			get;
			set;
		}

		public string Accept
		{
			get;
			set;
		}

		public string AcceptEncoding
		{
			get;
			set;
		}

		public int Timeout
		{
			get;
			set;
		}

		public string UserAgent
		{
			get;
			set;
		}

		public bool GZipCompress
		{
			get;
			set;
		}

		public bool KeepAlive
		{
			get;
			set;
		}

		public string CharacterSet
		{
			get;
			set;
		}

		public HttpConfig()
		{
			Timeout = 100000;
			ContentType = "text/html; charset=" + Encoding.UTF8.WebName;
			UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Safari/537.36";
			Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
			AcceptEncoding = "gzip,deflate";
			GZipCompress = false;
			KeepAlive = true;
			CharacterSet = "UTF-8";
		}
	}
}
