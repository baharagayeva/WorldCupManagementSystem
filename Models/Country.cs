using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldCupManagementSystem.Constants;

namespace WorldCupManagementSystem.Models
{
    public class Country:BaseModel
    {
        public string Name { get; set; }
        public Regions Region { get; set; }
        public Group Group { get; set; }
    }
}