using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.DataObjects.ECommerce
{
    public class SearchResult
    {
        public int ItemId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string SourceWebsite { get; set; }
    }
}
