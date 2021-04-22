using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR.Models
{
    public class VisitRequestDetailsModel
    {
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string VisitReason { get; set; }

    }
}
