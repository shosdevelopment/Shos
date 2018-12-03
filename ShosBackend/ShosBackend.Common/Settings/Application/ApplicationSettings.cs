using ShosBackend.Common.Enums;
using ShosBackend.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.Common.Settings.Application
{
    public interface IApplicationSettings
    {
        SystemEnvironment ThisEnvironment { get; }
        string AliExpressApiDomain { get; }
    }

    public class ApplicationSettings : IApplicationSettings
    {
        private readonly IConfigurationHelper _configurationHelper;

        public ApplicationSettings(IConfigurationHelper configurationHelper)
        {
            _configurationHelper = configurationHelper;
        }

        public SystemEnvironment ThisEnvironment => EnumUtils.Parse<SystemEnvironment>(_configurationHelper.GetString("ThisEnvironment"));

        public string AliExpressApiDomain => _configurationHelper.GetString("AliExpressApiDomain");
    }
}
