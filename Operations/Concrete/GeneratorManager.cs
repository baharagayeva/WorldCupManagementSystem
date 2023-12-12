using System;
using System.Collections.Generic;
using WorldCupManagementSystem.Constants;
using WorldCupManagementSystem.Database;
using WorldCupManagementSystem.Models;
using WorldCupManagementSystem.Operations.Abstract;

namespace WorldCupManagementSystem.Operations.Concrete
{
    public class GeneratorManager
    {
        //singleton -- thread safety
        private readonly IGroupOperation _groupOperation = new GroupManager();
        private readonly ICountryOperation _countryOperation = new CountryManager();
        private static GeneratorManager _instance;
        public static GeneratorManager Instance => _instance;
        private GeneratorManager() { }
        static GeneratorManager()
        {
            _instance = new GeneratorManager();
        }
        public void GenerateGroups()
        {
            int groupCount = DefaultConstantValues.DEFAULT_MAX_COUNTRY_COUNT / DefaultConstantValues.DEFAULT_PARTICIPANT_COUNT;
            for (int i = 1; i <= groupCount; i++)
            {
                var countries = _countryOperation.GetRandomNextFourCountry().Data;

                Group group = new Group();
                group.Name = DefaultConstantValues.UPPERCASE_NONNUMERIC_ALPHABET[i-1].ToString();
                group.ParticipantCount = DefaultConstantValues.DEFAULT_PARTICIPANT_COUNT;
                group.ID = _groupOperation.GetNextId().Data;

                group.Participants = countries;

                foreach (var item in countries)
                {
                    WorldCupDB.Countries.Find(x => x.ID == item.ID).Group = group;
                }

                _groupOperation.Add(group);
            }
        }
    }
}