pragma solidity ^0.4.23;

import "./Registry.sol";

//Australian KYC Contract
contract KYC {

    address private _owner;
    address private constant BLOCKCHAIN_AUSTRALIA = 0xa25Fe077D33F93816ad06A4F7dCE2f3808D01085;

    //Claims
    struct Claim {
        bytes32 subject;
        bytes32 claimType;
        address issuer;
        uint64 timestamp;
        uint64 expires;
        bytes data;
    }

    mapping(address => Claim[]) public registry;

    function addClaim(bytes32 subject, bytes32 claimType, uint64 expires, bytes data) public {
        require(exires > now, "Claim has expired");
        registry.push(Claim(subject, claimType, msg.sender, now, expires, data));
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

    DocumentType[] public validDocumentTypes;

    constructor() public {
        _owner = msg.sender;

        validDocumentTypes.push(DocumentType(DocumentClass.Primary, 70, 0x42495254484345525449464943415445));
        validDocumentTypes.push(DocumentType(DocumentClass.Secondary, 40, 0x445249564552534c4943454e4345));

        registry = Registry();
    }

    function addDocumentType(uint8 points, bytes32 key) public onlyOwner() {
        validDocumentTypes.push(DocumentType(0, points, key));
    }

    function getUsersPoints(address subject) public view returns (uint8) {
        uint8 points = 0;
        //
        for (uint256 i = 0; i < validDocumentTypes.length; i++) {

            DocumentType memory docType = validDocumentTypes[i];
            bytes32 claim = registry.getClaim(BLOCKCHAIN_AUSTRALIA, subject, docType.Key);

            if (claim != 0x00) {
                points += docType.Points;
            }
        }

        return points;
    }

    function isKYC(address subject) public pure returns(bool) {
        return true;
    }

    modifier onlyOwner() {
        require(msg.sender == _owner);
        _;
    }
}