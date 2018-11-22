using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiClient;
using ShosBackend.Common.ApiClient;
using ShosBackend.DataObjects.Enums;
using ShosBackend.DataObjects.Requests;
using ShosBackend.DataObjects.Responses;

namespace ShosBackend.ECommerceServices.Search
{
    public class AmazonSearchService : SearchService
    {
        private readonly IApiClient<AmazonSearchApiClientSettings> _amazonSearchApiClient;

        public AmazonSearchService(IApiClient<AmazonSearchApiClientSettings> amazonSearchApiClient)
        {
            _amazonSearchApiClient = amazonSearchApiClient;
        }

        public override SearchByQueryResponse Search(SearchByQueryRequest request)
        {
            throw new NotImplementedException();
        }

        public override bool CanProvide(ECommerceWebSite eCommerceWebSite)
        {
            return eCommerceWebSite == ECommerceWebSite.Amazon;
        }
    }
}
