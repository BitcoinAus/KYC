using System;
namespace KYC.MVC.Models
{
    public class Query
    {
		public String Key { get; set; }

		public String Issuer { get; set; }
        
        public String Subject { get; set; }
        
		public Query()
        {
        }
    }
}