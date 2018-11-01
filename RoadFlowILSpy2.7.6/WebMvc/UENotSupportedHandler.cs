using System.Web;

public class UENotSupportedHandler : UEHandler
{
	public UENotSupportedHandler(HttpContext context)
		: base(context)
	{
	}

	public override void Process()
	{
		WriteJson(new
		{
			state = "action 参数为空或者 action 不被支持。"
		});
	}
}
