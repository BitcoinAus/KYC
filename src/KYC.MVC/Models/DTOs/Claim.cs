using Nethereum.ABI.FunctionEncoding.Attributes;
using System;

namespace KYC.MVC.Models.DTOs
{
    public class Claim : IClaim
    {
        [Parameter("address", "subject", 1)]
        public string Subject { get; set; }

        [Parameter("bytes32", "key", 2)]
        public string Key { get; set; }

        [Parameter("bytes32", "value", 3)]
        public byte[] Value { get; set; }
    }
}