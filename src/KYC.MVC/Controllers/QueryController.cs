using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KYC.MVC.Models;

namespace KYC.MVC.Controllers
{
    public class QueryController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index(String id)
        {
            return View();
        }

        public async Task<IActionResult> Find(QueryRequest model)
        {
			//Web3 web3 = new Web3(ethereumNodeUrl);
			//var contract = web3.Eth.GetContract(abi, contract_address);

			//var getClaim = contract.GetFunction("getClaim");
			//var value = await getClaim.CallAsync<String>(model.Issuer, model.Subject, model.Key);


			ClaimsContract contract = new ClaimsContract(node);
			String value = await contract.GetClaim(model.Subject, model.Key);

            return View(value);
        }
    }
}