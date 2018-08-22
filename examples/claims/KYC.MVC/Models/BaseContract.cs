using System;
namespace KYC.MVC.Models
{
    public abstract class BaseContract
    {
		//internal string ethereumNodeUrl = "https://rinkeby.infura.io/RqID87GolHAMOx5Ws3ud";

		internal string ethereumNodeUrl = "http://localhost:7545";

		internal const Int64 gas = 900000;
    }
}
