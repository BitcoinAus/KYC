pragma solidity ^0.4.24;

//Simple repository contract to store data
contract ERC780 {

    mapping(address => mapping(address => mapping(bytes32 => bytes32))) public registry;

    event ClaimSet(address indexed issuer, address indexed subject, bytes32 indexed key, bytes32 value, uint updatedAt);
    event ClaimRemoved(address indexed issuer, address indexed subject, bytes32 indexed key, uint removedAt);

    function setClaim(address subject, bytes32 key, bytes32 value) external;
    function setSelfClaim(bytes32 key, bytes32 value) external;
    function getClaim(address issuer, address subject, bytes32 key) external view returns(bytes32);
    function removeClaim(address issuer, address subject, bytes32 key) external;
}