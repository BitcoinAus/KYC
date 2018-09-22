using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KYC.MVC.Models;
using Microsoft.AspNetCore.Mvc;
//using Nethereum.HdWallet;
using Microsoft.Extensions.Configuration;
using Nethereum.RPC.Accounts;
using Newtonsoft.Json;
using System.Text.Encodings;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KYC.MVC.Controllers
{
    public class DriversController : BaseController
    {
        public DriversController(IConfiguration configuration)
        {
            base.node = configuration.GetSection("Node").Value;
            base.api_key = configuration.GetSection("Providers").GetSection("RapidID").GetSection("APIKey").Value;
        }
        
        // GET: /<controller>/
        public IActionResult Create()
        {
            Drivers driver = new Drivers()
            {
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
        public async Task <IActionResult> Create(Drivers model)
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
            var httpContent = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
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
                    
                    IAccount account = new Nethereum.Web3.Accounts.Account(base.GetKey(0), Nethereum.Signer.Chain.Rinkeby);

                    ClaimsContract contract = new ClaimsContract(node, account);
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
    }
}
