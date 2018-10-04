pragma solidity ^0.4.24;

import "./Ownable.sol";

//List of ID providers
contract Whitelist is Ownable {

    struct Provider {
        string Name;
        address PublicKey;
        string Url;
    }

    mapping(address => Provider) Providers;

    constructor() public {
    }

    function add(string name, address key, string url) public onlyOwner()  {
        Providers[key] = Provider(name, key, url);
    }

    function remove(address subject) public onlyOwner() {
        delete Providers[subject];
    }
}