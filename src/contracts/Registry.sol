pragma solidity ^0.4.24;

//Simple repository contract to store data
contract Registry {

    mapping(address => mapping(address => mapping(bytes32 => bytes32))) public registry;

    mapping(address => Claim[]) claims;

    struct Claim {
        address Subject;
        bytes32 Key;
        bytes32 Value;
        uint256 Added;
        uint256 Expiry;
    }

    //struct from https://github.com/ethereum/EIPs/issues/735
    struct Claimx {
        uint256 topic;
        uint256 scheme;
        address issuer; // msg.sender
        bytes signature; // this.address + topic + data
        bytes data;
        string uri;
    }

    // create or update clams
    // function setClaim(address subject, bytes32 key, bytes32 value) external {
    //     registry[msg.sender][subject][key] = value;

    //     emit ClaimSet(msg.sender, subject, key, value, now);
    // }

    function setClaim(address subject, bytes32 key, bytes32 value, uint256 expires) external {
        require(expires > now, "Cannot add an expired claim");

        //registry[msg.sender][subject][key] = value;
        claims[msg.sender].push(Claim(subject, key, value, now, expires));

        emit ClaimSet(msg.sender, subject, key, value, now);
    }


    // function setSelfClaim(bytes32 key, bytes32 value, uint256 expires) external {
    //     //setClaim(msg.sender, key, value, expires);
    // }

    function getClaim(address issuer, address subject, bytes32 key) external view returns(bytes32) {
        return registry[issuer][subject][key];
    }

    function removeClaim(address issuer, address subject, bytes32 key) external {
        require(msg.sender == issuer, "Cannot remove claim");

        delete registry[issuer][subject][key];
        emit ClaimRemoved(msg.sender, subject, key, now);
    }

    event ClaimSet(address indexed issuer, address indexed subject, bytes32 indexed key, bytes32 value, uint updatedAt);
    event ClaimRemoved(address indexed issuer, address indexed subject, bytes32 indexed key, uint removedAt);
}