pragma solidity ^0.4.23;

contract Whitelist {

    address private _owner;

    mapping(address => address) Verified;

    constructor() public {
        _owner = msg.sender;
    }

    function add(address subject) onlyOwner public {
        Verified[subject] = subject;
    }

    modifier onlyOwner() {
        require(_owner == msg.sender);
        _;
    }
}