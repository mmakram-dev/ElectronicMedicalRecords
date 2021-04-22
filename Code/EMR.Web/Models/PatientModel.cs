using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMR.Models
{
    public class PatientModel
    {
        public string PatientId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Hospital { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime DischargeDate { get; set; }

        public string VisitReason { get; set; }

        public string Key { get; set; }

        public string MedicalCondition { get; set; }

        [Required]
        [Display(Name = "Residential Address")]
        public string ResidentialAddress { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "Invalid postal code")]
        
        [Display(Name = "Postal Code")]
        public string PostalAddress { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Employer { get; set; }
        [Required]
        [Range(0, 150, ErrorMessage = "Not a valid age")]
        public string Age { get; set; }
        [Required]
        public string Insurance { get; set; }
        [Required]
        [Display(Name = "Past Medical Problems")]
        public string PastProblems { get; set; }        
        [Required]
        [Display(Name = "Common Family Diseases")]
        public string FamilyHistory { get; set; }
        [Required]
        [Display(Name = "Current Problems")]
        public string CurrentProblems { get; set; }
        [Required]
        public string Medications { get; set; }
        [Required]
        public string Allergies { get; set; }
        public DateTime RequestDate { get; set; }

    }
}
