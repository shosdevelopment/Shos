namespace ApiClient.Settings.Abstraction
{
	public interface IApiClientSettings
	{
		string BaseUrl { get; }
		string AuthorizationToken { get; }
	}

	public abstract class ApiClientSettings : IApiClientSettings
	{
		public abstract string BaseUrl { get; }

		public virtual string AuthorizationToken
		{
			get { return null; }
		}
	}
}
