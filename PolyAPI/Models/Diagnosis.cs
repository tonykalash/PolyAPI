using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            Bookings = new HashSet<Booking>();
        }

        public int DiagnosisId { get; set; }
        public string? DiagnosisCode { get; set; }
        public string? DiagnosisName { get; set; }
        public string? DiagnosisDescription { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
