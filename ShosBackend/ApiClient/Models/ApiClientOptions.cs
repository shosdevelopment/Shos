using System.Net;
using System.Net.Http;
using ApiClient.Enums;

namespace ApiClient.Models
{
	public class ApiClientOptions
	{
		private string _endPointAddress = "";
		public string EndPointAddress
		{
			get { return _endPointAddress; }
			set { _endPointAddress = value; }
		}

		public object ParametersObject { get; set; }

		public CookieCollection CookieCollection { get; set; }

		private ApiClientRequestType _requestType = ApiClientRequestType.Json;
		public ApiClientRequestType RequestType
		{
			get { return _requestType; }
			set { _requestType = value; }
		}

		private HttpMethod _method = HttpMethod.Get;
		internal HttpMethod Method
		{
			get { return _method; }
			set { _method = value; }
		}

		private ApiClientResponseType _responseType = ApiClientResponseType.Automatic;
		public ApiClientResponseType ResponseType
		{
			get { return _responseType; }
			set { _responseType = value; }
		}
	}
}
