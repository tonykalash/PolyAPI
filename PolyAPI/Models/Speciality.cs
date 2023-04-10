using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int SpecialityId { get; set; }
        public string? SpecialityName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
