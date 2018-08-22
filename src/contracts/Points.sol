pragma solidity ^0.4.23;

contract Points {

    address private _owner;
    address private claimsRegistry = 0xC9ed21FfCc88a5072454c43BDFdBbE3430888b19;

    //
    enum PrimaryDocumentTypes {
        Passport,
        BirthCertificate //0x42495254484345525449464943415445
    }

    enum Class {
        Primary,
        Secondary
    }

    struct DocumentValue {
        Class class;
        uint8 points;
        bytes32 key;
    }

    DocumentValue[] public validDocuments;

    constructor() public {
        _owner = msg.sender;

        validDocuments.push(DocumentValue(Class.Primary, 70, 0x42495254484345525449464943415445));
        validDocuments.push(DocumentValue(Class.Secondary, 40, 0x445249564552534c4943454e4345));
    }

    function getPoints(address subject) public view returns(uint) {
        return 70;
    }
}