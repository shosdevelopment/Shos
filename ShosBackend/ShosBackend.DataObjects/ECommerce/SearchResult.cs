using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.DataObjects.ECommerce
{
    public class SearchResult
    {
        public int TotalProducts { get; set; }

        public List<ProductResult> Products { get; set; }
    }
}
