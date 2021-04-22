using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR.Infrastructure
{
    public class Common
    {
        private static List<string> specialityList = new List<string>() { 
            "Neuropathy",
            "Cardiology",
            "Orthopedic",
            "Gastroenterology",
            "Radiology",
            "Urology",
            "Dermatology",
            "Anesthesiology"

        };

        public static List<string> SpecialtyList { get => specialityList; set => specialityList = value; }
    }
}
