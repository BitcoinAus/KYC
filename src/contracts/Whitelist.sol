pragma solidity ^0.4.23;

//List of ID providers
contract Whitelist {

    address private _owner;

    mapping(address => address) Provider;

    constructor() public {
        _owner = msg.sender;
    }

    function add(address subject) public onlyOwner  {
        Provider[subject] = subject;
    }

    // function remove(address subject) onlyOwner public {
    //     Verified[subject] = subject;
    // }

    modifier onlyOwner() {
        require(_owner == msg.sender);
        _;
    }
}