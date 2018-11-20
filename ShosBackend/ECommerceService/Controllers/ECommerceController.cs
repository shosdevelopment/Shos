using ShosBackend.Common.ExtensionMethods;
using ShosBackend.DataObjects.Requests;
using ShosBackend.DataObjects.Responses;
using ShosBackend.Interfaces;
using System.Web.Http;
using System.Linq;
using ShosBackend.DataObjects.Enums;

namespace ECommerceService.Controllers
{
    public class ECommerceController : ApiController
    {
        private readonly ISearchService[] _SearchServices;

        public ECommerceController(ISearchService[] searchServices)
        {
            _SearchServices = searchServices;
        }

        [Route("search/amazon")]
        [HttpGet]
        public SearchByQueryResponse SearchAmazon(SearchByQueryRequest request)
        {
            if (request == null || request.SearchQuery.IsNullOrEmpty())
                return new SearchByQueryResponse { IsSuccess = false };
            return new SearchByQueryResponse { IsSuccess = true };
        }

        [Route("search/ebay")]
        [HttpGet]
        public SearchByQueryResponse SearchEbay(SearchByQueryRequest request)
        {
            var searchService = _SearchServices.First
                (service => service.CanProvide(ECommerceWebSite.Ebay));

            return searchService.Search(request);
        }
    }
}
