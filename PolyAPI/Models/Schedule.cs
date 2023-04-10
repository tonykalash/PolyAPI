using System;
using System.Collections.Generic;

namespace PolyAPI.Models
{
    public partial class Schedule
    {
        public int DoctorId { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public TimeSpan? ScheduleTime { get; set; }
    }
}
