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
    public class RefereeManager : IRefereeOperation
    {
        public IResult Add(Referee entity)
        {
            WorldCupDB.Referees.Add(entity);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(int id)
        {
            WorldCupDB.Referees.Remove(WorldCupDB.Referees.Find(x => x.ID == id));
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<Referee> Get(int id)
        {
            return new SuccessDataResult<Referee>(WorldCupDB.Referees.FirstOrDefault(x => x.ID == id));
        }

        public IDataResult<List<Referee>> GetAll()
        {
            return new SuccessDataResult<List<Referee>>(WorldCupDB.Referees);
        }

        public IDataResult<int> GetNextId()
        {
            if (!WorldCupDB.Referees.Any())
            {
                return new SuccessDataResult<int>(DefaultConstantValues.DEFAULT_MODEL_INITIAL_ID);
            }
            return new SuccessDataResult<int>(WorldCupDB.Referees.Max(x => x.ID) + 1);
        }

        public IResult Update(Referee entity)
        {
            var updatedItem = WorldCupDB.Referees.FirstOrDefault(x => x.ID == entity.ID);
            updatedItem = entity;
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}