using ApiClient.Enums;

namespace ApiClient.ExtensionMethods
{
	internal static class ApiClientRequestTypeExtensions
	{
		public static string ToMediaType(this ApiClientRequestType requestType)
		{
			switch (requestType)
			{
				case ApiClientRequestType.Json:
					return "application/json";
				case ApiClientRequestType.Xml:
					return "application/xml";
				case ApiClientRequestType.FormUrlEncoded:
					return "application/x-www-form-urlencoded";
				default:
					return "text/plain";
			}
		}
	}
}
