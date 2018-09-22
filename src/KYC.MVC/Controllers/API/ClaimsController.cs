using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KYC.MVC.Controllers
{
    [Route("api/[controller]")]
    public class ClaimsController : Controller
    {
        private const string ethereumNodeUrl = "https://rinkeby.infura.io/RqID87GolHAMOx5Ws3ud";

        //Rinkeby
		private const string contract_id = "0xC9ed21FfCc88a5072454c43BDFdBbE3430888b19";

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var web3 = new Nethereum.Web3.Web3(ethereumNodeUrl);

            //var abi = GetAbi();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
