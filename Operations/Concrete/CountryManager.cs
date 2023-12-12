using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldCupManagementSystem.Constants;
using WorldCupManagementSystem.Database;
using WorldCupManagementSystem.Models;
using WorldCupManagementSystem.Operations.Abstract;

namespace WorldCupManagementSystem.Operations.Concrete
{
    public class CountryManager : ICountryOperation
    {
        public IResult Add(Country entity)
        {
            var businessOperationResult = ProjectHelper.ExecuteBusinessLogics(
                                                        CheckDuplicateCountry(entity),
                                                        CheckMaxCountryLimitExceededOrNot());

            if (!businessOperationResult.IsSuccess)
            {
                return businessOperationResult;
            }

            WorldCupDB.Countries.Add(entity);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(int Id)
        {
            WorldCupDB.Countries.Remove(WorldCupDB.Countries.Find(x => x.ID == Id));
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<Country> Get(int id)
        {
            return new SuccessDataResult<Country>(WorldCupDB.Countries.FirstOrDefault(x => x.ID == id));
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(WorldCupDB.Countries);
        }

        public IDataResult<int> GetNextId()
        {
            if (!WorldCupDB.Countries.Any())
            {
                return new SuccessDataResult<int>(DefaultConstantValues.DEFAULT_MODEL_INITIAL_ID);
            }
            
            return new SuccessDataResult<int>(WorldCupDB.Countries.Max(x => x.ID) + 1);
        }

        public IResult Update(Country entity)
        {
            var updatedItem = WorldCupDB.Countries.FirstOrDefault(x =>x.ID == entity.ID);
            updatedItem = entity;
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }

        private IResult CheckMaxCountryLimitExceededOrNot()
        {
            if(WorldCupDB.Countries.Count > DefaultConstantValues.DEFAULT_MAX_COUNTRY_COUNT)
            {
                return new ErrorResult(CountryMessages.MaxCountryCountExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckDuplicateCountry(Country country)
        {
            if (WorldCupDB.Countries.Any(x => x.Name.ToLower() == country.Name.ToLower()))
            {
                return new ErrorResult(CommonOperationMessages.DuplicateItemFound);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Country>> GetRandomNextFourCountry()
        {
            var filteredCountries = WorldCupDB.Countries.Where(x => x.Group is null).ToList();
            Random random = new Random();
            List<Country> countries = new List<Country>();
            int valueForRandom = filteredCountries.Count;

            for (int i = 1; i <= DefaultConstantValues.DEFAULT_PARTICIPANT_COUNT; i++)
            {
                int index = random.Next(0,valueForRandom);
                countries.Add(filteredCountries[index]);
                filteredCountries.Remove(filteredCountries[index]);
                valueForRandom--;
            }

            return new SuccessDataResult<List<Country>>(countries);
        }
    }
}