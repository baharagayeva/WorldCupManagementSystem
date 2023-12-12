using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldCupManagementSystem.Constants;

namespace WorldCupManagementSystem.Models
{
    public class Group:BaseModel
    {
        public string Name { get; set; }
        public byte ParticipantCount { get; set; }
        public List<Country> Participants { get; set; }

        public Group()
        {
            Participants = new List<Country>();
            ParticipantCount = DefaultConstantValues.DEFAULT_PARTICIPANT_COUNT;
        }

    }
}