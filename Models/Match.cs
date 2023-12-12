using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldCupManagementSystem.Models
{
    public class Match:BaseModel
    {
        public Country TeamOne { get; set; }
        public Country TeamTwo { get; set; }
        public DateTime MatchDay { get; set; }
        public Stadium Stadium { get; set; }
        public Group Group { get; set; }
        public bool IsGroupMatch { get; set; }
        public Referee Referee { get; set; }
    }
}