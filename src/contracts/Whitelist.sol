pragma solidity ^0.4.23;

//List of ID providers
contract Whitelist {

    address private _owner;

    struct Provider {
        string Name;
        address PublicKey;
        string Url;
    }

    mapping(address => Provider) Providers;

    constructor() public {
        _owner = msg.sender;
    }

    function add(string name, address key, string url) public onlyOwner()  {
        Providers[key] = Provider(name, key, url);
    }

    function remove(address subject) public onlyOwner() {
        delete Providers[subject];
    }

    modifier onlyOwner() {
        require(_owner == msg.sender);
        _;
    }
}