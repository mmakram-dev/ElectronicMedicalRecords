pragma solidity >=0.7.4;

contract DoctorContract {
  struct Doctor { 
        uint id;   
        string name;
        address add;
        string hospital;
        string specialty;
        string contactNumber;
        string password;
        string keys;
        string[] patientKeys;
  } 
  mapping (address => Doctor) public records;
  mapping (uint => address) public addressMap;

  
  uint public nextId = 0;

  function create(address add,
    string memory name,
    string memory password,    
    string memory hospital, 
    string memory contactNumber, 
    string memory specialty, 
    string memory keys) public {
    
    records[add].name = name;
    records[add].hospital = hospital;
    records[add].specialty = specialty;
    records[add].contactNumber = contactNumber;
    records[add].password = password;
    records[add].keys = keys;
    addressMap[nextId] = add;
    nextId++;
  }

  function addPatient(address doctorAdd, string memory patientKey) public {
    records[doctorAdd].keys = string(abi.encodePacked(records[doctorAdd].keys, '||', patientKey));// records[doctorAdd].keys + '||' + patientKey;
    nextId++;
  }

  function read(address add) view public returns (
            string memory _name,
            string memory _hospital,
            string memory _specialty,
            string memory _contactNumber,
            string memory _password,
            string memory _keys
        ) {

        _name = records[add].name;
        _hospital = records[add].hospital;
        _specialty = records[add].specialty;
        _contactNumber = records[add].contactNumber;
        _password = records[add].password;
        _keys = records[add].keys;
  }

  function update(address add, string memory name, string memory hospital,
   string memory specialty, string memory contactNumber, string memory password, string memory keys) public {
    records[add].name = name;
    records[add].hospital = hospital;
    records[add].specialty = specialty;
    records[add].contactNumber = contactNumber;
    records[add].password = password;
    records[add].keys = keys;
  }

  function find(uint id) view public returns(address) {
    return addressMap[id];
  }
}