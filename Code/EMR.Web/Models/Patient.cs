using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OptimizerApp.Models
{
    public class Patient
    {
        public int DoctorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Hospital { get; set; }

        [Required]
        public string Specialty { get; set; }
        public List<string> SpecialtyList { get; set; }


    }
}
