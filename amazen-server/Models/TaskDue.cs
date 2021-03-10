using System;

namespace amazen_server.Models
{
    public class TaskDue
    {
        public int PlaneId { get; set; }
        public int ItemNumber { get; set; }
        public string Description { get; set; }
        public string LogDate { get; set; }
        public int? LogHours { get; set; }
        public int? IntervalMonths { get; set; }
        public int? IntervalHours { get; set; }
        public DateTime? NextDue { get; set; }

    }
}