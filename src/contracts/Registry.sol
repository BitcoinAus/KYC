pragma solidity ^0.4.24;

//Simple repository contract to store data
//ERC735 or  939
contract Registry {

    struct Claim {
        bytes32 subject;
        bytes32 claimType;
        address issuer;
        uint64 timestamp;
        uint64 expires;
        bytes data;
    }

    mapping(address => Claim[]) public registry;

    function addClaim(bytes32 subject, bytes32 claimType, uint64 expires, bytes data) public returns (uint256 index) {
        require(exires > now, "Claim has expired");
        registry.push(Claim(subject, claimType, msg.sender, now, expires, data));

        returns registry[subject].length;
    }

    function getClaims(bytes32 subject, address issuer) public returns (uint256 index) {

    }

    event ClaimAdded();
}