
namespace WorldCupManagementSystem
    
{
    public abstract class Result : IResult
    {
        public string Message { get; }

        public bool IsSuccess {  get; }

        public Result(bool isSuccess) 
        { 
            IsSuccess = isSuccess;
        }
        public Result(string message, bool isSuccess):this(isSuccess) 
        { 
            Message = message;
        }
    }
}
