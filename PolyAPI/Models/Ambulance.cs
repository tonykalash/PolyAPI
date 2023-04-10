using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class Ambulance
    {
        public int AmbId { get; set; }
        public int DoctorId { get; set; }
        public int PatientCardId { get; set; }
        public DateTime? AmbDate { get; set; }
        public TimeSpan? AmbTime { get; set; }
        public string? AmbAddress { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient PatientCard { get; set; } = null!;
    }
}
