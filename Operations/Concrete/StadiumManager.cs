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
    public class StadiumManager : IStadiumOperation
    {
        public IResult Add(Stadium entity)
        {
            WorldCupDB.Stadiums.Add(entity);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(int id)
        {
            WorldCupDB.Stadiums.Remove(WorldCupDB.Stadiums.Find(x => x.ID == id));
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<Stadium> Get(int id)
        {
            return new SuccessDataResult<Stadium>(WorldCupDB.Stadiums.FirstOrDefault(x => x.ID == id));
        }

        public IDataResult<List<Stadium>> GetAll()
        {
            return new SuccessDataResult<List<Stadium>>(WorldCupDB.Stadiums);
        }

        public IDataResult<int> GetNextId()
        {
            if (!WorldCupDB.Stadiums.Any())
            {
                return new SuccessDataResult<int>(DefaultConstantValues.DEFAULT_MODEL_INITIAL_ID);
            }
            return new SuccessDataResult<int>(WorldCupDB.Stadiums.Max(x => x.ID) + 1);
        }

        public IResult Update(Stadium entity)
        {
            var updatedItem = WorldCupDB.Stadiums.FirstOrDefault(x => x.ID == entity.ID);
            updatedItem = entity;
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}