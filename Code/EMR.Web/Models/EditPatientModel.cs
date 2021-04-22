using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMR.Models
{
    public class EditPatientModel
    {
        public string Key { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Doctor Notes")]
        public string MedicalCondition { get; set; }

        [Display(Name = "Residential Address")]
        public string ResidentialAddress { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalAddress { get; set; }
        
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        public string Education { get; set; }
        
        public string Gender { get; set; }
        
        public string Employer { get; set; }
        
        public string Age { get; set; }
        
        public string Insurance { get; set; }
        
        [Display(Name = "Past Medical Problems")]
        public string PastProblems { get; set; }
        
        [Display(Name = "Common Family Diseases")]
        public string FamilyHistory { get; set; }
        
        [Display(Name = "Current Problems")]
        public string CurrentProblems { get; set; }
        
        //[Display(Name = "Medictions")]
        public string Medications { get; set; }
        
        public string Allergies { get; set; }

        public string Hospital { get; internal set; }

        public List<PatientCommentModel> PatientCommentModels { get; set; }
    }
}
