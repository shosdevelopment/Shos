using ApiClient.Settings.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.Common.ApiClient
{
    public class AmazonSearchApiClientSettings : ApiClientSettings
    {
        public override string BaseUrl => "http://webservices.amazon.com/onca/xml?Service=AWSECommerceService&";
    }
}
