using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace RoadFlow.Utility
{
	public class HttpHelper
	{
		private static bool RemoteCertificateValidate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true;
		}

		public static string SendPost(string url, string data)
		{
			return Send(url, "POST", data, null);
		}

		public static string SendGet(string url)
		{
			return Send(url, "GET", null, null);
		}

		public static string Send(string url, string method, string data, HttpConfig config)
		{
			if (config == null)
			{
				config = new HttpConfig();
			}
			using (HttpWebResponse httpWebResponse = GetResponse(url, method, data, config))
			{
				Stream stream = httpWebResponse.GetResponseStream();
				if (!string.IsNullOrEmpty(httpWebResponse.ContentEncoding))
				{
					if (httpWebResponse.ContentEncoding.Contains("gzip"))
					{
						stream = new GZipStream(stream, CompressionMode.Decompress);
					}
					else if (httpWebResponse.ContentEncoding.Contains("deflate"))
					{
						stream = new DeflateStream(stream, CompressionMode.Decompress);
					}
				}
				byte[] bytes = null;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					byte[] array = new byte[4096];
					int count;
					while ((count = stream.Read(array, 0, array.Length)) > 0)
					{
						memoryStream.Write(array, 0, count);
					}
					bytes = memoryStream.ToArray();
				}
				Encoding encoding;
				if (!string.IsNullOrEmpty(httpWebResponse.CharacterSet) && httpWebResponse.CharacterSet.ToUpper() != "ISO-8859-1")
				{
					encoding = Encoding.GetEncoding((httpWebResponse.CharacterSet == "utf8") ? "utf-8" : httpWebResponse.CharacterSet);
				}
				else
				{
					string @string = Encoding.Default.GetString(bytes);
					Match match = Regex.Match(@string, "<meta.*charset=\"?([\\w-]+)\"?.*>", RegexOptions.IgnoreCase);
					encoding = ((!match.Success) ? Encoding.GetEncoding(config.CharacterSet) : Encoding.GetEncoding(match.Groups[1].Value));
				}
				return encoding.GetString(bytes);
			}
		}

		private static HttpWebResponse GetResponse(string url, string method, string data, HttpConfig config)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = method;
			httpWebRequest.Referer = config.Referer;
			httpWebRequest.UserAgent = config.UserAgent;
			httpWebRequest.Timeout = config.Timeout;
			httpWebRequest.Accept = config.Accept;
			httpWebRequest.Headers.Set("Accept-Encoding", config.AcceptEncoding);
			httpWebRequest.ContentType = config.ContentType;
			httpWebRequest.KeepAlive = config.KeepAlive;
			if (url.ToLower().StartsWith("https"))
			{
				ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidate;
			}
			if (method.ToUpper() == "POST")
			{
				if (!string.IsNullOrEmpty(data))
				{
					byte[] array = Encoding.UTF8.GetBytes(data);
					if (config.GZipCompress)
					{
						using (MemoryStream memoryStream = new MemoryStream())
						{
							using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
							{
								gZipStream.Write(array, 0, array.Length);
							}
							array = memoryStream.ToArray();
						}
					}
					httpWebRequest.ContentLength = array.Length;
					httpWebRequest.GetRequestStream().Write(array, 0, array.Length);
				}
				else
				{
					httpWebRequest.ContentLength = 0L;
				}
			}
			return (HttpWebResponse)httpWebRequest.GetResponse();
		}

		public static string SendFile(string url, HttpPostedFile file)
		{
			byte[] array = new byte[file.InputStream.Length];
			file.InputStream.Read(array, 0, (int)file.InputStream.Length);
			return SendFile(url, file.FileName, array);
		}

		public static string SendFile(string url, string path, byte[] bf)
		{
			HttpWebRequest obj = WebRequest.Create(url) as HttpWebRequest;
			CookieContainer cookieContainer2 = obj.CookieContainer = new CookieContainer();
			obj.AllowAutoRedirect = true;
			obj.Method = "POST";
			string str = DateTime.Now.Ticks.ToString("X");
			obj.ContentType = "multipart/form-data;charset=utf-8;boundary=" + str;
			byte[] bytes = Encoding.UTF8.GetBytes("\r\n--" + str + "\r\n");
			byte[] bytes2 = Encoding.UTF8.GetBytes("\r\n--" + str + "--\r\n");
			string fileName = Path.GetFileName(path);
			StringBuilder stringBuilder = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"media\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
			byte[] bytes3 = Encoding.UTF8.GetBytes(stringBuilder.ToString());
			Stream requestStream = obj.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Write(bytes3, 0, bytes3.Length);
			requestStream.Write(bf, 0, bf.Length);
			requestStream.Write(bytes2, 0, bytes2.Length);
			requestStream.Close();
			return new StreamReader((obj.GetResponse() as HttpWebResponse).GetResponseStream(), Encoding.UTF8).ReadToEnd();
		}

		public static string DownloadFile(string url, string filePath)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "GET";
			using (httpWebRequest.GetResponse())
			{
				string address = ((HttpWebResponse)httpWebRequest.GetResponse()).ResponseUri.ToString();
				WebClient webClient = new WebClient();
				try
				{
					webClient.DownloadFile(address, filePath);
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
			return "";
		}
	}
}
