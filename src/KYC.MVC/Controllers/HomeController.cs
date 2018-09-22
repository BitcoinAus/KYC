using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KYC.MVC.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Accounts;
//using Nethereum.HdWallet;
using Microsoft.Extensions.Configuration;

namespace KYC.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public String ContractAddress { get; }

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            this.ContractAddress = _configuration.GetSection("Issuers").GetSection("Blockchain Australia").Value;
            ViewBag.ContractAddress = this.ContractAddress;
        }

        public IActionResult Index()
        {
			Models.QueryRequest query = new Models.QueryRequest() 
            { 
                Issuer = _configuration.GetSection("ClaimsContract").Value,
                Key = "0x445249564552534c4943454e4345", 
                Subject = "0x94D61685D2B7b656C38e7bedAca4f5743d1362c4" 
            };
            
            return View(query);
        }

        [HttpPost]
		public IActionResult Claim()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Ethereum KYC and uPort";
            return View();
        }
    }
}
