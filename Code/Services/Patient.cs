using PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Patient
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Password { get; set; }
        public string MedicalCondition { get; set; }
        public string VisitReason { get; set; }
        public long AdmissionDate { get; set; }
        public long DischargeDate { get; set; }
        public string Hospital { get; set; }
        public string Address { get; set; }
        public string PostalAddress { get; set; }
        public string ContactNumber { get; set; }
        public string ResidentialAddress { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Employer { get; set; }
        public string Education { get; set; }
        public string Insurance { get; set; }
        public string PastProblems { get; set; }
        public string FamilyHistory { get; set; }
        public string CurrentProblems { get; set; }
        public string Medications { get; set; }
        public string Allergies { get; set; }
        public List<PatientComment> patientComments { get; set; }

    }
}
