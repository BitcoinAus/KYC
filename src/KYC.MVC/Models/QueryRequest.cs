using System;

namespace KYC.MVC.Models
{
    public class QueryRequest
    {
		public String Key { get; set; }

		public String Issuer { get; set; }
        
        public String Subject { get; set; }
    }
}