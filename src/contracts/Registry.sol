pragma solidity ^0.4.24;

import "./Whitelist.sol";

contract Registry is Whitelist {

    address public owner;

    mapping(address => mapping(address => mapping(bytes32 => bytes32))) public registry;

    event ClaimSet(address indexed issuer, address indexed subject, bytes32 indexed key, bytes32 value, uint updatedAt);
    event ClaimRemoved(address indexed issuer, address indexed subject, bytes32 indexed key, uint removedAt);

    constructor () public {
        owner = msg.sender;
    }

    // create or update clams
    function setClaim(address subject, bytes32 key, bytes32 value) external {
        registry[msg.sender][subject][key] = value;
        emit ClaimSet(msg.sender, subject, key, value, now);
    }

    function setSelfClaim(bytes32 key, bytes32 value) external {
        setClaim(msg.sender, key, value);
    }

    function getClaim(address issuer, address subject, bytes32 key) external view returns(bytes32) {
        return registry[issuer][subject][key];
    }

    function removeClaim(address issuer, address subject, bytes32 key) external {
        require(msg.sender == issuer);

        delete registry[issuer][subject][key];
        emit ClaimRemoved(msg.sender, subject, key, now);
    }
}