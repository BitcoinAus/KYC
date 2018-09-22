using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KYC.MVC.Controllers
{ 
    public abstract class BaseController : Controller
    {
        internal String node;

        internal String api_key;

        internal async Task<String> AddClaim(Models.DTOs.Claim claim)
        {
            IAccount account = new Nethereum.Web3.Accounts.Account(base.GetKey(0), Nethereum.Signer.Chain.Rinkeby);

            ClaimsContract contract = new ClaimsContract(node, account);
            return await contract.SetClaim(claim.Subject, claim.Key, claim.Value);
        }
    }
}