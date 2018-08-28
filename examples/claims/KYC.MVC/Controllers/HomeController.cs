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
    public class HomeController : BaseController
    {        
        public HomeController(IConfiguration configuration)
        {
            
        }

        public IActionResult Index()
        {
			Query query = new Query() 
            { 
                Issuer = "0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085", 
                Key = "0x445249564552534c4943454e4345", 
                Subject = "0x94D61685D2B7b656C38e7bedAca4f5743d1362c4" 
            };
            
            return View(query);
        }
        
        public async Task<IActionResult> Query(Query model)
        {
			//Web3 web3 = new Web3(ethereumNodeUrl);
			//var contract = web3.Eth.GetContract(abi, contract_address);

			//var getClaim = contract.GetFunction("getClaim");
			//var value = await getClaim.CallAsync<String>(model.Issuer, model.Subject, model.Key);


			ClaimsContract contract = new ClaimsContract(node);
			String value = await contract.GetClaim(model.Subject, model.Key);

            return View();
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
