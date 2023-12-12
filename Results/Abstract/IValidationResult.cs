using System.Collections.Generic;

namespace WorldCupManagementSystem
{
    public interface IValidationResult
    {
        bool IsValid { get; }
        List<string> Errors { get; }
    }
}
