
namespace WorldCupManagementSystem

{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
