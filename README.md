# KYC

Problem Statement - Under new legislative requirements passed into law in Australia in 2018, all businesses providing exchange services into digital currencies such as Bitcoin need to be registered with AUSTRAC and need to complete due diligance with respect to AM/CT risk and to complete certain KYC checks depending on the above risks.

By implementing the following steps, we provide a way for a user to complete the KYC process once and have this verification available to other service providers in the Digital Exchange Service industry.

In order of this initial verification attestation to be valuable to other service providers, it must cover all of the checks required under Australian legislation. Initially this will be to complete 100 Points of Identification and a PEP check. Other verifications can be added at leter stages as required.

An entity will also have to be registered with AUSTRAC as the Designated Business Group (DBG) in order for other entities to use the verification undertaken by the DBG.

## Abstract
Using uPort or other wallets and ERC780 contracts to make portable KYC attestations.  Users will be able to verify their idenity once, use many across financial services.  This demo is on the Rinkeby network.

This code will enable white label KYC portals to be deployed.

There is provision in the existing legislative framework for this type of co-ordinated KYC approach to be undertaken. http://www.austrac.gov.au/chapter-3-designated-business-groups#what

## Process
The process to add a new user to the KYC smart contract is:
1. New users visits the portal https://id.blockchainaustralia.org
2. Complete an online form
3. The website is configured to use our KYC vendor RapidID - https://rapidid.com.au/home
4. A call to RapidID's REST API is posted
5. If verified, the data is hashed and submitted to the Ethereum blockchain

To verify a users 100 points of ID, they are asked to sign a message from the private key that holds their attestations.
1. The exchange website generates a unique message for that user. Eg I Lucas Cullen, am the owner of the address 0xa25Fe077D33F93816ad06A4F7dCE2f3808D0108529-08-2018
2. User generates the signed message from a wallet or service, such as https://www.myetherwallet.com/signmsg.html
3. If the signature is valid, the exchange can assert the user is correct

```
{
  "address": "0xa25fe077d33f93816ad06a4f7dce2f3808d01085",
  "msg": "I Lucas Cullen, am the owner of the address 0xa25Fe077D33F93816ad06A4F7dCE2f3808D0108529-08-2018",
  "sig": "0xad44f6f7d4cc87859437734546df99baafe343dac71452aea08aea7beaf754c97880513568163c28bccfca135a4e100bbc6c3d3a663737b31506d2f9f3fe34901b",
  "version": "3",
  "signer": "MEW"
}
```

## Contracts
There is one smart contract.

1. The KYC proxy that implements business logic functions, such as "points value"

## Claim types
Based on the 100 Point ID check Australia.  

| Key | Class | Document Type | Point Value | Key as Bytes32 |
| --- | --- | --- | --- | --- |
| BIRTHCERTIFICATE | Primary | Birth Certificate | 70 | 0x42495254484345525449464943415445 |
| PASSPORT | Primary | Passport | 70 | 0x50415353504f52540a |
| DRIVERSLICENCE | Secondary | Driver’s Licence | 40 | 0x445249564552534c4943454e4345 |
| RESIDENTALCOUNTRY | NA | Country of Residence | 0 | 0x5245534944454e54414c434f554e545259 |

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


## KYC contract
KYC contracts will determine the users KYC state, based on local laws.  These will be deployed from parties, such as Blockchain Australia.  Finanical services will call these top level contracts to determine their users KYC status.


## Document taxonomy

Primary and secondary documents are represented as JSON in the following formats.  The hash of the document is then added to the ERC780 register contract.

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

### KYC Contract Owners
| Name | Public Key | Url |
| --- | --- | --- |
| Blockchain Australia | 0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085 | https://blockchainaustralia.org/kyc |
| ConsenSys | 0x00 | |

## Validating 100 points
The "100" points proxy contract will iterate through the underling claims contact `0xc9ed21ffcc88a5072454c43bdfdbbe3430888b19`.  Using the key and points values from the above table, will then aggrate the total.

```
contract Points {
    
}
```

## Test keys
| Vendor | Private Key | Public Key |
| --- | --- | --- |
| "Blockchain Australia" | 0x3b3617c923fc5d7ea2aa1fc10d98e5b15cf1ade7b463c2dc929a1d2498137472 |0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085 |

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


