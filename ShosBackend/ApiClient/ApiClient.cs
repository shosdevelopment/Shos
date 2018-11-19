using System.Linq;
using System.Net.Http;
using ApiClient.Helpers;
using ApiClient.Models;
using ApiClient.Settings.Abstraction;

namespace ApiClient
{
	public interface IApiClient<TS> where TS : IApiClientSettings
	{
		ApiClientResult Get(ApiClientOptions apiClientOptions);
		ApiClientResult<T> Get<T>(ApiClientOptions apiClientOptions) where T : class;
		ApiClientResult Post(ApiClientOptions apiClientOptions);
		ApiClientResult<T> Post<T>(ApiClientOptions apiClientOptions) where T : class;
		ApiClientResult Put(ApiClientOptions apiClientOptions);
		ApiClientResult<T> Put<T>(ApiClientOptions apiClientOptions) where T : class;
		ApiClientResult Delete(ApiClientOptions apiClientOptions);
		ApiClientResult<T> Delete<T>(ApiClientOptions apiClientOptions) where T : class;
	}

	public class ApiClient<TS> : IApiClient<TS> where TS : IApiClientSettings
	{
		private readonly IApiClientSettings[] _apiClientSettings;
		private readonly IApiClientSettings _currentSettings;
		private readonly IApiClientHelper _apiClientHelper;

		public ApiClient(IApiClientSettings[] apiClientSettings)
		{
			_apiClientSettings = apiClientSettings;
			_currentSettings = _apiClientSettings.First(p => p.GetType() == typeof(TS));
			_apiClientHelper = new ApiClientHelper(_currentSettings);
		}

		public ApiClientResult Get(ApiClientOptions apiClientOptions)
		{
			apiClientOptions.Method = HttpMethod.Get;
			return _apiClientHelper.SendRequest(apiClientOptions);
		}

		public ApiClientResult<T> Get<T>(ApiClientOptions apiClientOptions) where T : class
		{
			apiClientOptions.Method = HttpMethod.Get;
			return _apiClientHelper.SendRequest<T>(apiClientOptions);
		}

		public ApiClientResult Post(ApiClientOptions apiClientOptions)
		{
			apiClientOptions.Method = HttpMethod.Post;
			return _apiClientHelper.SendRequest(apiClientOptions);
		}

		public ApiClientResult<T> Post<T>(ApiClientOptions apiClientOptions) where T : class
		{
			apiClientOptions.Method = HttpMethod.Post;
			return _apiClientHelper.SendRequest<T>(apiClientOptions);
		}

		public ApiClientResult Put(ApiClientOptions apiClientOptions)
		{
			apiClientOptions.Method = HttpMethod.Put;
			return _apiClientHelper.SendRequest(apiClientOptions);
		}

		public ApiClientResult<T> Put<T>(ApiClientOptions apiClientOptions) where T : class
		{
			apiClientOptions.Method = HttpMethod.Put;
			return _apiClientHelper.SendRequest<T>(apiClientOptions);
		}

		public ApiClientResult Delete(ApiClientOptions apiClientOptions)
		{
			apiClientOptions.Method = HttpMethod.Delete;
			return _apiClientHelper.SendRequest(apiClientOptions);
		}

		public ApiClientResult<T> Delete<T>(ApiClientOptions apiClientOptions) where T : class
		{
			apiClientOptions.Method = HttpMethod.Delete;
			return _apiClientHelper.SendRequest<T>(apiClientOptions);
		}
	}
}