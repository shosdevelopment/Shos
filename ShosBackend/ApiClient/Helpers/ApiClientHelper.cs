using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using ApiClient.Enums;
using ApiClient.ExtensionMethods;
using ApiClient.Models;
using ApiClient.Settings.Abstraction;

namespace ApiClient.Helpers
{
	internal interface IApiClientHelper
	{
		ApiClientResult SendRequest(ApiClientOptions apiClientOptions);
		ApiClientResult<T> SendRequest<T>(ApiClientOptions apiClientOptions) where T : class;
	}

	internal class ApiClientHelper : IApiClientHelper
	{
		private readonly IApiClientSettings _currentSettings;

		public ApiClientHelper(IApiClientSettings apiClientSettings)
		{
			_currentSettings = apiClientSettings;
		}

		public ApiClientResult SendRequest(ApiClientOptions apiClientOptions)
		{
			var httpClientHandler = GetClientHandler(apiClientOptions);
			using (var client = new HttpClient(httpClientHandler))
			{
				InitializeHttpClient(client, _currentSettings, apiClientOptions);

				var request = GenerateRequestMessage(apiClientOptions);

				var httpResponseMessage = client.SendAsync(request).WaitAndGetResult();

				var apiClientResult = ProcessResponseMessage(httpResponseMessage);

				if (httpClientHandler.CookieContainer != null)
				{
					var currentUri = new Uri(_currentSettings.BaseUrl + apiClientOptions.EndPointAddress);
					apiClientResult.Cookies = httpClientHandler.CookieContainer.GetCookies(currentUri);
				}
				
				return apiClientResult;
			}
		}

		public ApiClientResult<T> SendRequest<T>(ApiClientOptions apiClientOptions) where T : class
		{
			var httpClientHandler = GetClientHandler(apiClientOptions);
			using (var client = new HttpClient(httpClientHandler))
			{
				InitializeHttpClient(client, _currentSettings, apiClientOptions);

				var request = GenerateRequestMessage(apiClientOptions);

				var httpResponseMessage = client.SendAsync(request).WaitAndGetResult();

				var apiClientResult = ProcessResponseMessage<T>(httpResponseMessage, apiClientOptions);

				if (httpClientHandler.CookieContainer != null)
				{
					var currentUri = new Uri(_currentSettings.BaseUrl + apiClientOptions.EndPointAddress);
					apiClientResult.Cookies = httpClientHandler.CookieContainer.GetCookies(currentUri);
				} 

				return apiClientResult;
			}
		}

		private ApiClientResult ProcessResponseMessage(HttpResponseMessage httpResponseMessage)
		{
			var apiClientResult = new ApiClientResult();
			apiClientResult.Fill(httpResponseMessage);

			return apiClientResult;
		}

		private ApiClientResult<T> ProcessResponseMessage<T>(HttpResponseMessage httpResponseMessage, ApiClientOptions options) where T : class
		{
			var apiClientResult = new ApiClientResult<T>();
			apiClientResult.Fill(httpResponseMessage);

			T responseContent;

			if (!httpResponseMessage.IsSuccessStatusCode)
				responseContent = default(T);
			else
			{
				if (typeof(T) == typeof(String))
				{
					responseContent = apiClientResult.RawResponseContent as T;
				}
				else if (options.ResponseType == ApiClientResponseType.Xml)
				{
					var message = apiClientResult.RawResponseContent;
					var serializer = new XmlSerializer(typeof(T));

					using (var reader = new StringReader(message))
					{
						responseContent = serializer.Deserialize(reader) as T;
					}
				}
				else
				{
					responseContent = httpResponseMessage.Content.ReadAsAsync<T>().WaitAndGetResult();
				}
			}

			apiClientResult.ResponseContent = responseContent;

			return apiClientResult;
		}



		private HttpClientHandler GetClientHandler(ApiClientOptions apiClientOptions)
		{
			var clientHandler = new HttpClientHandler();

			if (apiClientOptions.CookieCollection != null)
			{
				var cookieContainer = new CookieContainer();
				cookieContainer.Add(apiClientOptions.CookieCollection);

				clientHandler.CookieContainer = cookieContainer;
			}

			return clientHandler;
		}

		private void InitializeHttpClient(HttpClient client, IApiClientSettings settings, ApiClientOptions options)
		{
			client.DefaultRequestHeaders.Accept.Clear();

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(options.RequestType.ToMediaType()));

			if (!string.IsNullOrEmpty(settings.AuthorizationToken))
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(settings.AuthorizationToken)));
			}
		}

		private HttpRequestMessage GenerateRequestMessage(ApiClientOptions options)
		{
			var requestUri = (_currentSettings.BaseUrl ?? "") + (options.EndPointAddress ?? "");

			if (options.Method == HttpMethod.Get || options.Method == HttpMethod.Delete)
			{
				var queryString = GetQueryString(options.ParametersObject);
				if (!string.IsNullOrEmpty(queryString)) requestUri += "?" + queryString;
			}
				
			var requestMessage = new HttpRequestMessage
				                     {
					                     Method = options.Method,
										 RequestUri = new Uri(requestUri)
				                     };

			if (options.Method != HttpMethod.Get && options.Method != HttpMethod.Delete)
				requestMessage.Content = GetHttpContent(options);

			return requestMessage;
		}

		private HttpContent GetHttpContent(ApiClientOptions options)
		{
			switch (options.RequestType)
			{
				case ApiClientRequestType.Xml:
				case ApiClientRequestType.Json:
					return new ObjectContent(options.ParametersObject.GetType(), options.ParametersObject, GetMediaTypeFormatter(options.RequestType));
				case ApiClientRequestType.FormUrlEncoded:
					return new FormUrlEncodedContent(GetPropertiesCollection(options.ParametersObject));
				default:
					return new StringContent(options.ParametersObject.ToString(), Encoding.UTF8, options.RequestType.ToMediaType());
			}

		}

		private MediaTypeFormatter GetMediaTypeFormatter(ApiClientRequestType requestType)
		{
			switch (requestType)
			{
				case ApiClientRequestType.Xml:
					return new XmlMediaTypeFormatter();
				default:
					return new JsonMediaTypeFormatter();
			}
		}

		private IEnumerable<KeyValuePair<string, string>> GetPropertiesCollection(object obj)
		{
			if (obj == null) return null;

			// If the object is a dictionary
			IDictionary idict = obj as IDictionary;
			if (idict != null) {
				return idict.Keys.Cast<object>()
					.Where(key => idict[key] != null)
					.Select(key => new KeyValuePair<string, string>(key.ToString(), idict[key].ToString()));
			}

			var objectProperties = obj.GetType().GetProperties();

			return objectProperties
				.Where(p => p.GetValue(obj, null) != null)
				.Select(p => new KeyValuePair<string, string>(p.Name, HttpUtility.UrlEncode(p.GetValue(obj, null).ToString())));
		}
		
		private string GetQueryString(object obj)
		{
			if (obj == null) return null;

			var properties = GetPropertiesCollection(obj);
			return string.Join("&", properties.Select(pair => pair.Key + "=" + pair.Value));
		}
		
	}
}
