using ApiClient.Settings;
using ApiClient.Settings.Abstraction;

namespace ApiClient
{
	// Creating an ApiClient class with default settings
	public interface IDefaultApiClient : IApiClient<DefaultApiClientSettings> { }

	public class DefaultApiClient : ApiClient<DefaultApiClientSettings>, IDefaultApiClient
	{
		public DefaultApiClient(IApiClientSettings[] apiClientSettings) : base(apiClientSettings) { }
	}
}
