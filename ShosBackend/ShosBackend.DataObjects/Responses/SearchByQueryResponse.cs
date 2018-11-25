using ShosBackend.DataObjects.ECommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.DataObjects.Responses
{
    public class SearchByQueryResponse
    {
        public bool IsSuccess { get; set; }

        public SearchResult SearchResult { get; set; }
    }
}
