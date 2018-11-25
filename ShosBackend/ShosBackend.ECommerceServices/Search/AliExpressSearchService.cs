using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiClient;
using ApiClient.Models;
using ShosBackend.Common.ApiClient;
using ShosBackend.DataObjects.ECommerce.AliExpress;
using ShosBackend.DataObjects.Enums;
using ShosBackend.DataObjects.Requests;
using ShosBackend.DataObjects.Responses;

namespace ShosBackend.ECommerceServices.Search
{
    public class AliExpressSearchService : SearchService
    {
        private readonly IApiClient<AliExpressSearchApiClientSettings> _aliExpressSearchApiClient;

        public AliExpressSearchService(IApiClient<AliExpressSearchApiClientSettings> aliExpressSearchApiClient)
        {
            _aliExpressSearchApiClient = aliExpressSearchApiClient;
        }

        public override SearchByQueryResponse Search(SearchByQueryRequest request)
        {
            var searchQuery = request.SearchQuery;
            var parameters = new
            {
                Keywords = searchQuery
            };

            var apiResult = _aliExpressSearchApiClient.Get<AliExpressSearchApiResult>(new ApiClientOptions
            {
                EndPointAddress = "",
                ParametersObject = parameters
            }).ResponseContent;

            if (apiResult == null) return new SearchByQueryResponse { IsSuccess = false };
            return new SearchByQueryResponse { IsSuccess = true }
        }

        public override bool CanProvide(ECommerceWebSite eCommerceWebSite)
        {
            return eCommerceWebSite == ECommerceWebSite.AliExpress;
        }
    }
}
