using System.Web;
using System.Web.Util;

namespace WebMvc.Common
{
	public class CustomRequestValidation : RequestValidator
	{
		protected override bool IsValidRequestString(HttpContext context, string value, RequestValidationSource requestValidationSource, string collectionKey, out int validationFailureIndex)
		{
			validationFailureIndex = 0;
			return true;
		}
	}
}
