using ShosBackend.DataObjects.Enums;
using ShosBackend.DataObjects.Requests;
using ShosBackend.DataObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.Interfaces
{
    public interface ISearchService
    {
        SearchByQueryResponse Search(SearchByQueryRequest request);
        bool CanProvide(ECommerceWebSite eCommerceWebSite);
    }
}
