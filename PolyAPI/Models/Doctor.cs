using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Ambulances = new HashSet<Ambulance>();
            Bookings = new HashSet<Booking>();
        }

        public int DoctorId { get; set; }
        public int? SpecialityId { get; set; }
        public string? DoctorCategory { get; set; }

        public virtual Speciality? Speciality { get; set; }
        public virtual ICollection<Ambulance> Ambulances { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
