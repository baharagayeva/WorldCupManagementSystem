using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldCupManagementSystem.Models;

namespace WorldCupManagementSystem.Database
{
    public static class WorldCupDB
    {
        public static List<Country> Countries = new List<Country>();
        public static List<Group> Groups = new List<Group>();
        public static List<Match> Matches = new List<Match>();
        public static List<Referee> Referees = new List<Referee>();
        public static List<Stadium> Stadiums = new List<Stadium>();
    }
}