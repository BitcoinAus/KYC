using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Accounts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KYC.MVC.Controllers
{ 
    public abstract class BaseController : Controller
    {
        internal String node;

        internal String api_key;

        internal String api_url;

        internal async Task<String> AddClaim(Models.DTOs.Claim claim)
        {
            IAccount account = GetAccount();

            ClaimsContract contract = new ClaimsContract(node, account);
            return await contract.SetClaim(claim.Subject, claim.Key, claim.Value);
        }

        internal IAccount GetAccount()
        {
            return new Nethereum.Web3.Accounts.Account("831b5bb9f83bca4da5939044921ba30d3eaa9712234a496270fecc8a6ae40d7c");
        }
    }
}