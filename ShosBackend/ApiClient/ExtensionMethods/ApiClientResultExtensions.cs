using System.Net.Http;
using ApiClient.Models;

namespace ApiClient.ExtensionMethods
{
	public static class ApiClientResultExtensions
	{
		public static void Fill(this ApiClientResult apiClientResult, HttpResponseMessage httpResponseMessage)
		{
			apiClientResult.RawResponseContent = httpResponseMessage.Content.ReadAsStringAsync().WaitAndGetResult();
			apiClientResult.StatusCode = httpResponseMessage.StatusCode;
			apiClientResult.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
			apiClientResult.Headers = httpResponseMessage.Headers;
		}
	}
}
