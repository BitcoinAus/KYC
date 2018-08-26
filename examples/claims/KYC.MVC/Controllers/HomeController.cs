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

namespace KYC.MVC.Controllers
{
    public class HomeController : Controller
    {
        private const String url = "https://sandbox.rapidid.com.au/dvs/driverLicence";

        private const String api_key = "075c4cccb5144349bd94035b29c387c5067375d978e9caed2d0709a8f73274ef";

        private const String ethereumNodeUrl = "https://rinkeby.infura.io/RqID87GolHAMOx5Ws3ud";

        //Rinkeby
        private const String contract_address = "0xC9ed21FfCc88a5072454c43BDFdBbE3430888b19";

        //Blockchain australia
        private const String issuer_address = "0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085";

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


			ClaimsContract contract = new ClaimsContract(ethereumNodeUrl);
			String value = await contract.GetClaim(model.Subject, model.Key);

            return View();
        }

        public IActionResult Drivers()
        {
			Drivers driver = new Drivers()
			{
				//uPortAddress = "0x94D61685D2B7b656C38e7bedAca4f5743d1362c4",
                GivenName = "Mary",
                FamilyName = "Lee",
                BirthDate = "1985-02-08",
                LicenceNumber = "94977000",
                StateOfIssue = "ACT",
                CountryCode = "AUS"
			};
            
            return View(driver);
        }

        [HttpPost]
        public async Task <IActionResult> Drivers(Drivers model)
        {
            Models.RaidID.DriversRequest request = new Models.RaidID.DriversRequest()
            {
                BirthDate = model.BirthDate,
                FamilyName = model.FamilyName,
                GivenName = model.GivenName,
                LicenceNumber = model.LicenceNumber,
                StateOfIssue = model.StateOfIssue
            };

            var payload = JsonConvert.SerializeObject(request);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            httpContent.Headers.Add("token", api_key);

			using (var httpClient = new HttpClient())
			{
				// Do the actual request and await the response
				var httpResponse = await httpClient.PostAsync(url, httpContent);

				// If the response contains content we want to read it!
				if (httpResponse.Content != null && httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
				{
					var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var claim = model.ToClaim();
                    
                    IAccount account = new Nethereum.Web3.Accounts.Account("0x3b3617c923fc5d7ea2aa1fc10d98e5b15cf1ade7b463c2dc929a1d2498137472", Nethereum.Signer.Chain.Rinkeby);

					ClaimsContract contract = new ClaimsContract(ethereumNodeUrl, account);
                    
					String tx = await contract.SetClaim(claim.Subject, claim.Key, claim.Value);

                    ViewBag.Tx = tx;

					return View();
				}
				else
				{
					return View("error");
				}
			}
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
