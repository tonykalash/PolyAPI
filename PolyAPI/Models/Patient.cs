using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Ambulances = new HashSet<Ambulance>();
            Bookings = new HashSet<Booking>();
        }

        public int PatientId { get; set; }
        public int PatientCardId { get; set; }
        public string? PatientCardLocation { get; set; }
        public string? PatientBirthdate { get; set; }
        public string? PatientAddress { get; set; }
        public string? PatientGender { get; set; }
        public float? PatientDiscount { get; set; }

        public virtual ICollection<Ambulance> Ambulances { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
