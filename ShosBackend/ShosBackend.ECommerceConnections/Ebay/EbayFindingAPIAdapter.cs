using ShosBackend.ECommerceConnections.com.ebay.developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShosBackend.ECommerceConnections.Ebay
{
    public class EbayFindingAPIAdapter : FindingService
    {
        private const string AppId = "shosdeve-shos-PRD-af8f85d15-64122de1";
        public List<string> OperationsList { get; set; }
        public List<string> ServicesList { get; set; }
        public List<string> GlobalIds { get; set; }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
                request.Headers.Add("X-EBAY-SOA-SECURITY-APPNAME", AppId);
                request.Headers.Add("X-EBAY-SOA-OPERATION-NAME", "findItemsByKeywords");
                request.Headers.Add("X-EBAY-SOA-SERVICE-NAME", "FindingService");
                request.Headers.Add("X-EBAY-SOA-MESSAGE-PROTOCOL", "SOAP11");
                request.Headers.Add("X-EBAY-SOA-SERVICE-VERSION", "1.0.0");
                request.Headers.Add("X-EBAY-SOA-GLOBAL-ID", "EBAY-US");

                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
