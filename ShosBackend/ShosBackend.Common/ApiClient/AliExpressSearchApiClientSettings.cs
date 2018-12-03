using ApiClient.Settings.Abstraction;
using ShosBackend.Common.Settings.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.Common.ApiClient
{
    public class AliExpressSearchApiClientSettings : ApiClientSettings
    {
        private readonly IApplicationSettings _applicationSettings;

        public AliExpressSearchApiClientSettings(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }
        public override string BaseUrl => _applicationSettings.AliExpressApiDomain;
    }
}
