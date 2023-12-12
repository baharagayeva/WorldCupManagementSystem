using System.Collections.Generic;
using WorldCupManagementSystem.Models;

namespace WorldCupManagementSystem.Operations.Abstract
{
    public interface ICountryOperation : IBaseOperation<Country>
    {
        IDataResult<List<Country>> GetRandomNextFourCountry();
    }
}
