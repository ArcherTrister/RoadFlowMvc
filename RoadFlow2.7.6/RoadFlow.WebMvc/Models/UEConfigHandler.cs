using System.Web;

public class UEConfigHandler : UEHandler
{
	public UEConfigHandler(HttpContext context)
		: base(context)
	{
	}

	public override void Process()
	{
		WriteJson(UEConfig.Items);
	}
}
