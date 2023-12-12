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
    public class MatchManager : IMatchOperation
    {
        public IResult Add(Match entity)
        {
            WorldCupDB.Matches.Add(entity);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(int id)
        {
            WorldCupDB.Matches.Remove(WorldCupDB.Matches.Find(x => x.ID == id));
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<Match> Get(int id)
        {
            return new SuccessDataResult<Match>(WorldCupDB.Matches.FirstOrDefault(x => x.ID == id));
        }

        public IDataResult<List<Match>> GetAll()
        {
            return new SuccessDataResult<List<Match>>(WorldCupDB.Matches);
        }

        public IDataResult<int> GetNextId()
        {
            if (!WorldCupDB.Matches.Any())
            {
                return new SuccessDataResult<int>(DefaultConstantValues.DEFAULT_MODEL_INITIAL_ID);
            }
            return new SuccessDataResult<int>(WorldCupDB.Matches.Max(x => x.ID) + 1);
        }

        public IResult Update(Match entity)
        {
            var updatedItem = WorldCupDB.Matches.FirstOrDefault(x => x.ID == entity.ID);
            updatedItem = entity;
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}