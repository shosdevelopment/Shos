using ShosBackend.Common.ExtensionMethods;
using ShosBackend.DataObjects.Requests;
using ShosBackend.DataObjects.Responses;
using System.Web.Http;


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
