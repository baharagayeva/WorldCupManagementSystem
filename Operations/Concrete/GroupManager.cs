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
    public class GroupManager : IGroupOperation
    {
        public IResult Add(Group entity)
        {
            WorldCupDB.Groups.Add(entity);
            return new SuccessResult(CommonOperationMessages.DataAddedSuccessfully);
        }

        public IResult Delete(int id)
        {
            WorldCupDB.Groups.Remove(WorldCupDB.Groups.Find(x => x.ID == id));
            return new SuccessResult(CommonOperationMessages.DataDeletedSuccessfully);
        }

        public IDataResult<Group> Get(int id)
        {
            return new SuccessDataResult<Group>(WorldCupDB.Groups.FirstOrDefault(x => x.ID == id));
        }

        public IDataResult<List<Group>> GetAll()
        {
            return new SuccessDataResult<List<Group>>(WorldCupDB.Groups);
        }

        public IDataResult<int> GetNextId()
        {
            if (!WorldCupDB.Groups.Any())
            {
                return new SuccessDataResult<int>(DefaultConstantValues.DEFAULT_MODEL_INITIAL_ID);
            }
            return new SuccessDataResult<int>(WorldCupDB.Groups.Max(x => x.ID) + 1);
        }

        public IResult Update(Group entity)
        {
            var updatedItem = WorldCupDB.Groups.FirstOrDefault(x => x.ID == entity.ID);
            updatedItem = entity;
            return new SuccessResult(CommonOperationMessages.DataUpdatedSuccessfully);
        }
    }
}