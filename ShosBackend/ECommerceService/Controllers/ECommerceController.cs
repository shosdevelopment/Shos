using DataObjects.Requests;
using DataObjects.Responses;
using System.Web.Http;
using UtilsService.ExtensionMethods;

namespace ECommerceService.Controllers
{
    public class ECommerceController : ApiController
    {
        public ECommerceController()
        {

        }

        public SearchByQueryResponse Search(SearchByQueryRequest request)
        {
            if(request == null || request.SearchQuery.IsNullOrEmpty())
                return new SearchByQueryResponse { IsSuccess = false };
            return new SearchByQueryResponse { IsSuccess = true };
        }
    }
}
