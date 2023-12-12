using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldCupManagementSystem.Models
{
    public class Stadium:BaseModel
    {
        public String Name { get; set; }
        public string Location { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentAttendanceCount { get; set; }
    }
}