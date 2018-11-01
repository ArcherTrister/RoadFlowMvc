using Newtonsoft.Json;
using System.Web;

public abstract class UEHandler
{
	public HttpRequest Request
	{
		get;
		private set;
	}

	public HttpResponse Response
	{
		get;
		private set;
	}

	public HttpContext Context
	{
		get;
		private set;
	}

	public HttpServerUtility Server
	{
		get;
		private set;
	}

	public UEHandler(HttpContext context)
	{
		Request = context.Request;
		Response = context.Response;
		Context = context;
		Server = context.Server;
	}

	public abstract void Process();

	protected void WriteJson(object response)
	{
		string text = Request["callback"];
		string text2 = JsonConvert.SerializeObject(response);
		if (string.IsNullOrWhiteSpace(text))
		{
			Response.AddHeader("Content-Type", "text/plain");
			Response.Write(text2);
		}
		else
		{
			Response.AddHeader("Content-Type", "application/javascript");
			Response.Write(string.Format("{0}({1});", text, text2));
		}
		Response.End();
	}
}
