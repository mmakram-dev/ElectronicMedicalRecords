pragma solidity >=0.7.4;
struct Patient {   
        string name;
        string password;
        address add;
        string hospital;
        string visitReason;
        string medicalCondition;       
}

struct PatientInfo{
        string residentialAddress;
        string postalCode;
        string contactNumber;
        string age;
        string gender;
        string employer;
        string eduction;
        string insurance;        
} 

struct PatientMedicalInfo{
        string pastProblems;
        string familyHistory;
        string currentProblems;
        string medications;
        string allergies;
}

struct PatientReports{
        string doctorName;
        string date;
        string text;
}

