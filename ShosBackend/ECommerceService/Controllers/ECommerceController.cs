using ShosBackend.Common.ExtensionMethods;
using ShosBackend.DataObjects.Requests;
using ShosBackend.DataObjects.Responses;
using ShosBackend.Interfaces;
using System.Web.Http;
using System.Linq;
using ShosBackend.DataObjects.Enums;

namespace ECommerceService.Controllers
{
    [RoutePrefix("search")]
    public class ECommerceController : ApiController
    {
        private readonly ISearchService[] _SearchServices;

        public ECommerceController(ISearchService[] searchServices)
        {
            _SearchServices = searchServices;
        }

        [Route("amazon")]
        [HttpGet]
        public SearchByQueryResponse SearchAmazon([FromUri] SearchByQueryRequest request)
        {
            var searchService = _SearchServices.First
                (service => service.CanProvide(ECommerceWebSite.Amazon));

            return searchService.Search(request);
        }

        [Route("ebay")]
        [HttpGet]
        public SearchByQueryResponse SearchEbay([FromUri] SearchByQueryRequest request)
        {
            var searchService = _SearchServices.First
                (service => service.CanProvide(ECommerceWebSite.Ebay));

            return searchService.Search(request);
        }
    }
}
