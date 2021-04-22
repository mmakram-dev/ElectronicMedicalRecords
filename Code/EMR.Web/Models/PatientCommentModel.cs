using System;

namespace EMR.Models
{
    public class PatientCommentModel
    {
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}