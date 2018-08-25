# KYC

## Abstract
Using uPort or other wallets and ERC780 contracts to make portable KYC attestations.  Users will be able to verify their idenity once, use many across financial services.  This demo is on the Rinkeby network.

This code will enable white label KYC portals to be deployed.

## Process
The process to add a new user to the KYC smart contract is:
1. New users visits the portal https://id.blockchainaustralia.org
2. Complete an online form
3. The website is configured to use a reputal KYC vendor, such as RaidID
4. A call to RapidID's REST API is posted
5. If verified, the data is hashed and submitted to the Ethereum blockchain

## Claim types
Based on the 100 Point ID check Australia.  

| Key | Class | Document Type | Point Value | Key as Bytes32 |
| --- | --- | --- | --- | --- |
| BIRTHCERTIFICATE | Primary | Birth Certificate | 70 | 0x42495254484345525449464943415445 |
| DRIVERSLICENCE | Secondary | Driver’s Licence | 40 | 0x445249564552534c4943454e4345 |

Classes represented in the smart contract as an enum
```
enum Class {
    Primary,
    Secondary
}
```

Once documents have been certified, their Key and the hash of the JSON object are added to the users public key.

```
struct Document {
	Key,
	Hash,
	Date,
	Verified
}
```


## Proxy contract



## Document taxonomy

Primary and secondary documents are represented as JSON in the following formats.  The hash of the document is then added to the ERC780 register.

``
{
	'BIRTHCERTIFICATE': '0x00'
}
``

### BIRTHCERTIFICATE

| Key | Eg Value |
| --- | --- | --- |
| Key | BIRTHCERTIFICATE |
| Name | JOHN DOE |
| Issued | 2018-01-01 |

```
{
    Key: 'BIRTHCERTIFICATE',
    Name: 'JOHN DOE',
    Issued: '2018-01-01'
    Documents: [

    ]
}
```

```
{
	BirthDate: '2005-08-21',
	FamilyName: 'Smith',
	GivenName: 'Larry',
	RegistrationState: 'NSW',
	RegistrationDate: '2005-08-27',
	RegistrationYear: '2005',
	RegistrationNumber: '500156',
	CertificateNumber: '1758461',
	DatePrinted: '2012-07-27'
}
```

### DRIVERSLICENCE
```
{
	BirthDate: '1985-02-08',
	FamilyName: 'Lee',
	GivenName: 'Mary',
	LicenceNumber: '94977000',
	StateOfIssue: 'ACT',
    Country: 'AUS'
}
```

Flattening the object

```
{\"uPortAddress\":null,\"CountryCode\":\"AUS\",\"Key\":\"DRIVERSLICENCE\",\"BirthDate\":\"1985-02-08\",\"GivenName\":\"Mary\",\"FamilyName\":\"Lee\",\"LicenceNumber\":\"94977000\",\"StateOfIssue\":\"ACT\"}
```

Eg SHA-256 hash `0xa9dc32cc4b5416158dabefae23c8c6bd000841755a58e4c29e920af2705df604`

## Participants

### KYC issuers
Australian issuers

| Name | Public Key | Url |




### Exchanges and other money remittance services


### End users


### Contract vettors
| Name | Public Key |
---
| Blockchain Australia | 0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085 |
| ConsenSys | 0x00 |
| ADCA | 0x00 |


## Contract specs

The contract to holds clients KYC attestations will adhere to ERC780.  We are using the uPort contract ``, deployed on Rinkeby at `0xc9ed21ffcc88a5072454c43bdfdbbe3430888b19`.

## Validating 100 points
The "100" points proxy contract will iterate through the underling claims contact `0xc9ed21ffcc88a5072454c43bdfdbbe3430888b19`.  Using the key and points values from the above table, will then aggrate the total.

```
contract Points {
    
}
```

## Test keys
"Blockchain Australia" 0x3b3617c923fc5d7ea2aa1fc10d98e5b15cf1ade7b463c2dc929a1d2498137472 0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085

## References

ERC 780 specs https://github.com/ethereum/EIPs/issues/780


First iteration of this is now available at uport-project/ethereum-claims-registry!
It's also deployed to the following addresses:
Rinkeby (id: 4) 	`0xc9ed21ffcc88a5072454c43bdfdbbe3430888b19`

https://rinkeby.etherscan.io/address/0xc9ed21ffcc88a5072454c43bdfdbbe3430888b19
https://github.com/uport-project/ethereum-claims-registry

JSON
https://raw.githubusercontent.com/uport-project/ethereum-claims-registry/master/build/contracts/EthereumClaimsRegistry.json


100 Point ID check Australia
https://www.homeaffairs.gov.au/Licensing/Documents/100-points-identification-guidelines.pdf


uPort App
Public Key 0x04b9d33dbc805cbc574b849d6f55e5022a5d07f4df46e6001d9bfb08b306d7a62ac3ca37ffa70abac019be6ab2ffb3db7045e63b755e65d9b73a6438531b75e712

Address `2ofGDsP2Rb51Bt76jVjSzresYwxgKcqyGbs` or `0x94D61685D2B7b656C38e7bedAca4f5743d1362c4`


Azure web app
https://kyc-token.azurewebsites.net/

Deployment creds
lucascullen Test1234

ISO 3166-1 Country codes


