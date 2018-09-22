using System;
namespace KYC.MVC.Models
{
    public class HomeViewModel
    {
        public String ContractAddress { get; internal set; }
        
        public Models.QueryRequest Query { get; set; }

        public HomeViewModel()
        {
            this.Query = new QueryRequest();
        }

        public HomeViewModel(QueryRequest model)
        {
            this.Query = model;
        }
    }
}