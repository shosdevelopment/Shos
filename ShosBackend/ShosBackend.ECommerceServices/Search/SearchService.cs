using ShosBackend.DataObjects.Enums;
using ShosBackend.DataObjects.Requests;
using ShosBackend.DataObjects.Responses;
using ShosBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.ECommerceServices.Search
{

    public abstract class SearchService : ISearchService
    {
        public abstract SearchByQueryResponse Search(SearchByQueryRequest request);
        public abstract bool CanProvide(ECommerceWebSite eCommerceWebSite);
    }
}
