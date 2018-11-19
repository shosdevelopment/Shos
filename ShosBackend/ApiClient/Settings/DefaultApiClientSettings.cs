using ApiClient.Settings.Abstraction;

namespace ApiClient.Settings
{
	public class DefaultApiClientSettings : ApiClientSettings
	{
		public override string BaseUrl
		{
			get { return ""; }
		}
	}
}