pragma solidity >=0.7.3;

import "./patientstruct.sol";

contract PatientContract {
  
  mapping (address => Patient) public records;
  mapping (address => PatientInfo) public recordsInfo;
  mapping (address => PatientMedicalInfo) public recordsMedInfo;
  mapping (address => PatientReports) public recordsReports;

  Patient[] public users;
  uint public nextId = 1;

  function create(
                address add,
                string memory name,
                string memory password,
                string memory hospital, 
                string memory visitReason,
                string memory medicalCondition
               ) public {

    records[add].name = name;
    records[add].hospital = hospital;
    records[add].visitReason = visitReason;
    records[add].password = password;
    records[add].medicalCondition = medicalCondition;
    nextId++;
  }

  function createInfo(
                address add,              
                string memory residentialAddress,
                string memory postalCode,
                string memory contactNumber,
                string memory age,
                string memory gender,
                string memory employer,
                string memory eduction,
                string memory insurance
) public {
    
    recordsInfo[add].residentialAddress = residentialAddress;
    recordsInfo[add].postalCode = postalCode;
    recordsInfo[add].contactNumber = contactNumber;
    recordsInfo[add].age = age;
    recordsInfo[add].gender = gender;
    recordsInfo[add].employer = employer;
    recordsInfo[add].eduction = eduction;
    recordsInfo[add].insurance = insurance;
    nextId++;
  }

function createMedics(
                address add,              
                string memory pastProblems,
                string memory familyHistory,
                string memory currentProblems,
                string memory medications,
                string memory allergies) public {

    recordsMedInfo[add].pastProblems = pastProblems;
    recordsMedInfo[add].familyHistory = familyHistory;
    recordsMedInfo[add].currentProblems = currentProblems;
    recordsMedInfo[add].medications = medications;
    recordsMedInfo[add].allergies = allergies;
    nextId++;
  }

  function read(address add) view public returns (
            string memory _name,
            string memory _password,
            string memory _hospital,
            string memory  _visitReason,
            string memory  _medicalCondition
        ) {

        _name = records[add].name;
        _password = records[add].password;
        _hospital = records[add].hospital;
        _visitReason = records[add].visitReason;
        _medicalCondition = records[add].medicalCondition;
  }

  function readInfo(address add) view public returns (           
                string memory _residentialAddress,
                string memory _postalCode,
                string memory _contactNumber,
                string memory _age,
                string memory _gender,
                string memory _employer,
                string memory _eduction,
                string memory _insurance
              
        ) {

        _residentialAddress = recordsInfo[add].residentialAddress;
        _age = recordsInfo[add].age;
        _postalCode = recordsInfo[add].postalCode;
        _contactNumber = recordsInfo[add].contactNumber;
        _gender = recordsInfo[add].gender;
        _employer = recordsInfo[add].employer;
        _eduction = recordsInfo[add].eduction;
        _insurance = recordsInfo[add].insurance;       
  }

  function readMedics(address add) view public returns (
                string memory _pastProblems,
                string memory _familyHistory,
                string memory _currentProblems,
                string memory _medications,
                string memory _allergies
        ) {

        _pastProblems = recordsMedInfo[add].pastProblems;
        _familyHistory = recordsMedInfo[add].familyHistory;
        _currentProblems = recordsMedInfo[add].currentProblems;
        _medications = recordsMedInfo[add].medications;
        _allergies = recordsMedInfo[add].allergies;
  }


  function update(address add, string memory name, string memory password, string memory hospital,
   string memory visitReason, string memory medicalCondition) public {
    records[add].name = name;
    records[add].hospital = hospital;
    records[add].visitReason = visitReason;
    records[add].password = password;
    records[add].medicalCondition = medicalCondition;
  }

  function updateInfo(address add,              
                string memory residentialAddress,
                string memory postalCode,
                string memory contactNumber,
                string memory age,
                string memory gender,
                string memory employer,
                string memory eduction,
                string memory insurance) public {
    recordsInfo[add].residentialAddress = residentialAddress;
    recordsInfo[add].postalCode = postalCode;
    recordsInfo[add].contactNumber = contactNumber;
    recordsInfo[add].age = age;
    recordsInfo[add].gender = gender;
    recordsInfo[add].employer = employer;
    recordsInfo[add].eduction = eduction;
    recordsInfo[add].insurance = insurance;
  }

  function updateMedics(address add,   
                string memory pastProblems,
                string memory familyHistory,
                string memory currentProblems,
                string memory medications,
                string memory allergies) public {
   
    recordsMedInfo[add].pastProblems = pastProblems;
    recordsMedInfo[add].familyHistory = familyHistory;
    recordsMedInfo[add].currentProblems = currentProblems;
    recordsMedInfo[add].medications = medications;
    recordsMedInfo[add].allergies = allergies;
  }

  function addComment(address add,              
                string memory doctorName,
                string memory date,
                string memory text) public {
    recordsReports[add].doctorName = doctorName;
    recordsReports[add].date = date;
    recordsReports[add].text = text;    
  }

  function readComments(address add) view public returns (
                string memory _doctorName,
                string memory _date,
                string memory _text
        ) {

        _doctorName = recordsReports[add].doctorName;
        _date = recordsReports[add].date;
        _text = recordsReports[add].text;
  }

}