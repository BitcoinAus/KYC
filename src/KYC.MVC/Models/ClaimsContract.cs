using System;
using Nethereum.Web3;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;

namespace KYC.MVC.Models
{
	public class ClaimsContract : BaseContract, IContract
	{
		private readonly Nethereum.RPC.Accounts.IAccount account;
        
		private const string abi = @"[
        {
            'constant': true,
            'inputs': [
            {
                'name': '',
                'type': 'address'
            },
            {
                'name': '',
                'type': 'address'
            },
            {
                'name': '',
                'type': 'bytes32'
            }
            ],
            'name': 'registry',
            'outputs': [
            {
                'name': '',
                'type': 'bytes32'
            }
            ],
            'payable': false,
            'stateMutability': 'view',
            'type': 'function'
        },
        {
            'anonymous': false,
            'inputs': [
            {
                'indexed': true,
                'name': 'issuer',
                'type': 'address'
            },
            {
                'indexed': true,
                'name': 'subject',
                'type': 'address'
            },
            {
                'indexed': true,
                'name': 'key',
                'type': 'bytes32'
            },
            {
                'indexed': false,
                'name': 'value',
                'type': 'bytes32'
            },
            {
                'indexed': false,
                'name': 'updatedAt',
                'type': 'uint256'
            }
            ],
            'name': 'ClaimSet',
            'type': 'event'
        },
        {
            'anonymous': false,
            'inputs': [
            {
                'indexed': true,
                'name': 'issuer',
                'type': 'address'
            },
            {
                'indexed': true,
                'name': 'subject',
                'type': 'address'
            },
            {
                'indexed': true,
                'name': 'key',
                'type': 'bytes32'
            },
            {
                'indexed': false,
                'name': 'removedAt',
                'type': 'uint256'
            }
            ],
            'name': 'ClaimRemoved',
            'type': 'event'
        },
        {
            'constant': false,
            'inputs': [
            {
                'name': 'subject',
                'type': 'address'
            },
            {
                'name': 'key',
                'type': 'bytes32'
            },
            {
                'name': 'value',
                'type': 'bytes32'
            }
            ],
            'name': 'setClaim',
            'outputs': [],
            'payable': false,
            'stateMutability': 'nonpayable',
            'type': 'function'
        },
        {
            'constant': false,
            'inputs': [
            {
                'name': 'key',
                'type': 'bytes32'
            },
            {
                'name': 'value',
                'type': 'bytes32'
            }
            ],
            'name': 'setSelfClaim',
            'outputs': [],
            'payable': false,
            'stateMutability': 'nonpayable',
            'type': 'function'
        },
        {
            'constant': true,
            'inputs': [
            {
                'name': 'issuer',
                'type': 'address'
            },
            {
                'name': 'subject',
                'type': 'address'
            },
            {
                'name': 'key',
                'type': 'bytes32'
            }
            ],
            'name': 'getClaim',
            'outputs': [
            {
                'name': '',
                'type': 'bytes32'
            }
            ],
            'payable': false,
            'stateMutability': 'view',
            'type': 'function'
        },
        {
            'constant': false,
            'inputs': [
            {
                'name': 'issuer',
                'type': 'address'
            },
            {
                'name': 'subject',
                'type': 'address'
            },
            {
                'name': 'key',
                'type': 'bytes32'
            }
            ],
            'name': 'removeClaim',
            'outputs': [],
            'payable': false,
            'stateMutability': 'nonpayable',
            'type': 'function'
        }
        ]";

		public string ABI
		{
			get
			{
				return abi;
			}
		}

		public String Address
		{
			get
			{
				return "0xC9ed21FfCc88a5072454c43BDFdBbE3430888b19";
			}
		}
        
        public ClaimsContract(String node)
        {
			base.ethereumNodeUrl = node;
        }
        
        public ClaimsContract(String node, Nethereum.RPC.Accounts.IAccount account)
        {
            base.ethereumNodeUrl = node;
			this.account = account;
        }

        public async Task<String> SetClaim(String subject, String key, Byte[] value)
		{
            try
            {
                Web3 web3 = new Web3(account, ethereumNodeUrl);
                var contract = web3.Eth.GetContract(this.ABI, this.Address);

                var setClaim = contract.GetFunction("setClaim");
                var txHash = await setClaim.SendTransactionAsync(account.Address, new HexBigInteger(900000), null, subject, key, value);
                return txHash;
            }
            catch (Exception ex)
            {
                return "";
            }
		}
        
        public async Task<String> GetClaim(String subject, String key)
        {
            Web3 web3 = new Web3(ethereumNodeUrl);
            var contract = web3.Eth.GetContract(this.ABI, this.Address);

            var getClaim = contract.GetFunction("getClaim");
			var value = await getClaim.CallAsync<String>(subject, key);

			return value;
        }
	}
}