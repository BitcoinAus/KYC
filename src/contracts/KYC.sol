pragma solidity ^0.4.23;

import "./Registry.sol";

//Australian KYC Contract
contract KYC {

    address private _owner;
    address private _defaultProvider = 0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085;

    Registry registry;

    //
    enum PrimaryDocumentTypes {
        DRIVERSLICENCE, //0x445249564552534c4943454e4345
        BIRTHCERTIFICATE //0x42495254484345525449464943415445
    }

    enum DocumentClass {
        Primary,
        Secondary
    }

    struct DocumentType {
        DocumentClass Class;
        uint8 Points;
        bytes32 Key;
    }

    struct KYCProvider {
        address PublicKey;
        string Name;
        string Url;
    }

    DocumentType[] public validDocumentTypes;

    mapping(address=> KYCProvider) validKYCProviders;

    constructor() public {
        _owner = msg.sender;

        validDocumentTypes.push(DocumentValue(Class.Primary, 70, 0x42495254484345525449464943415445));
        validDocumentTypes.push(DocumentValue(Class.Secondary, 40, 0x445249564552534c4943454e4345));

        //ERC780
        registry = Registry(0xC9ed21FfCc88a5072454c43BDFdBbE3430888b19);
    }

    function addDocumentType() public onlyOwner() {

    }

    function apply(address publicKey, string name, string url) public payable {
        require(msg.value >= 1 ether, "Must be 1 eth");
        //validKYCProviders[msg.sender] =
    }

    function addVendor(address publicKey, string name, string url) public onlyOwner() {
        validKYCProviders[msg.sender] = KYCProvider(publicKey, name, url);
    }

    function getUsersPoints(address subject) public view returns (uint8) {
        uint8 points = 0;
        //
        for (int i = 0; i < validDocumentTypes.length; i++) {
            DocumentType memory docType = validDocumentTypes[i];
            bytes32 claim = registry.getClaim(provider, subject, docType.Key);

            if (claim != 0x00) {
                points += docType.Ponts;
            }
        }

        return points;
    }

    function isKYC(address subject) public pure returns(bool) {
        return true;
    }

    modifier onlyOwner() {
        registry(msg.sender == owner);
        _;
    }
}