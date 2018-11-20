using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShosBackend.DataObjects.ECommerce;
using ShosBackend.DataObjects.Enums;
using ShosBackend.DataObjects.Requests;
using ShosBackend.DataObjects.Responses;
using ShosBackend.ECommerceConnections.com.ebay.developer;
using ShosBackend.ECommerceConnections.Ebay;

namespace ShosBackend.ECommerceServices.Search
{
    public class EbaySearchService : SearchService
    {

        private const string FindingServiceURL = "http://svcs.ebay.com/services/search/FindingService/v1";
        //"http://developer.ebay.com/webservices/Finding/latest/FindingService.wsdl";

        public override SearchByQueryResponse Search(SearchByQueryRequest request)
        {
            try
            {
                EbayFindingAPIAdapter service = new EbayFindingAPIAdapter();
                FindItemsByKeywordsRequest findItemsRequest = new FindItemsByKeywordsRequest();

                service.Url = FindingServiceURL;
                findItemsRequest.keywords = request.SearchQuery;
                // Setting the pagination
                PaginationInput pagination = new PaginationInput();
                pagination.entriesPerPageSpecified = true;
                pagination.entriesPerPage = 25;
                pagination.pageNumberSpecified = true;
                pagination.pageNumber = 1;

                findItemsRequest.paginationInput = pagination;
                // Creating response object
                FindItemsByKeywordsResponse response = service.findItemsByKeywords(findItemsRequest);
                var result = response.searchResult;

                return new SearchByQueryResponse
                {
                    IsSuccess = true,
                    SearchResults = new List<DataObjects.ECommerce.SearchResult>()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("* Error: " + ex.Message);
                return new SearchByQueryResponse { IsSuccess = false };
            }
        }

        public override bool CanProvide(ECommerceWebSite eCommerceWebSite)
        {
            return eCommerceWebSite == ECommerceWebSite.Ebay;
        }
    }
}
