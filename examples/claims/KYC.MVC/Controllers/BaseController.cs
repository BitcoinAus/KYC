using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KYC.MVC.Controllers
{ 
    public abstract class BaseController : Controller
    {
        internal const String url = "https://sandbox.rapidid.com.au/dvs/driverLicence";

        internal const String api_key = "075c4cccb5144349bd94035b29c387c5067375d978e9caed2d0709a8f73274ef";
    
        internal String node = "https://rinkeby.infura.io/RqID87GolHAMOx5Ws3ud";
    
        //Rinkeby
        internal const String contract_address = "0xC9ed21FfCc88a5072454c43BDFdBbE3430888b19";
    
        //Blockchain australia
        internal const String issuer_address = "0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085";

		internal String key = "";
        
        internal String GetKey(int index)
        {
			return "0x3b3617c923fc5d7ea2aa1fc10d98e5b15cf1ade7b463c2dc929a1d2498137472"; 
        }
    }
}