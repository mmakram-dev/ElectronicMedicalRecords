using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMR.Models
{
    public class VisitRequestModel
    {
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Visit Reason")]
        public string VisitReason { get; set; }

        public List<string> SpecialtyList { get; set; }

        [Required]
        public string Doctor { get; set; }
        public List<AddressDoctorMap> DoctorList { get; set; }


    }
}
