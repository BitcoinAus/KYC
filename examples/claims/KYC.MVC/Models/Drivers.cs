using KYC.MVC.Models.DTOs;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KYC.MVC.Models
{
    public class Drivers : RaidID.DriversRequest
    {
        [DisplayName("Ethereum Address")]
        public String Address { get; set; }

        [DisplayName("Country Code")]
		[RegularExpression(@"[A-Z]{3}", ErrorMessage = "Invalid Country Code")]
        public string CountryCode { get; set; }

        //TODO: Review
        public string Key { get { return "445249564552534c4943454e4345"; } }

        public Byte[] GetHash()
        {
            return null;
        }

        public IClaim ToClaim()
        {
			String flat = Newtonsoft.Json.JsonConvert.SerializeObject(this);
			var hash = Helpers.sha256_hash(Newtonsoft.Json.JsonConvert.SerializeObject(this));
            
            return new Claim() { Subject = Address, Key = "445249564552534c4943454e4345", Value = hash };
        }
    }
}
