using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int PatientCardId { get; set; }
        public int DoctorId { get; set; }
        public int PriceId { get; set; }
        public int DiagnosisId { get; set; }
        public string? BookingDescription { get; set; }

        public virtual Diagnosis Diagnosis { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient PatientCard { get; set; } = null!;
        public virtual Price Price { get; set; } = null!;
    }
}
