using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Accounts;
using Nethereum.Web3;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KYC.MVC.Controllers.API
{
    [Route("api/[controller]")]
    public class ContractController : Controller
    {

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<String> Post(String byteCode)
        {
            IAccount account = new Nethereum.Web3.Accounts.Account("0x3b3617c923fc5d7ea2aa1fc10d98e5b15cf1ade7b463c2dc929a1d2498137472", Nethereum.Signer.Chain.Rinkeby);
            Web3 web3 = new Web3(account, "http://localhost:7545");

			String tx = await web3.Eth.DeployContract.SendRequestAsync(byteCode, "0x627306090abaB3A6e1400e9345bC60c78a8BEf57");

			return tx;
        }
    }
}
