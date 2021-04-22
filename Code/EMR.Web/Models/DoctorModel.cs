using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMR.Models
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Hospital { get; set; }

        [Required]
        public string Specialty { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public List<string> SpecialtyList { get; set; }

        [Display(Name = "Verficiation Code")]
        public string VerificationCode { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
    }
}
