using System.Net;
using System.Net.Http.Headers;

namespace ApiClient.Models
{
	public class ApiClientResult
	{
		public string RawResponseContent { get; internal set; }

		public bool IsSuccessStatusCode { get; internal set; }

		public HttpStatusCode StatusCode { get; internal set; }

		public HttpResponseHeaders Headers { get; internal set; }

		public CookieCollection Cookies { get; internal set; }
	}

	public class ApiClientResult<T> : ApiClientResult
		where T : class
	{
		public T ResponseContent { get; internal set; }
	}
}
