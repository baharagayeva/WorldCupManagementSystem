using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldCupManagementSystem
{
    public static class ProjectHelper
    {
        public static IResult ExecuteBusinessLogics(params IResult[] results)
        {
            foreach (var result in results)
                {
                if (!result.IsSuccess)
                {
                    return new ErrorResult(result.Message);
                }
            }
            return new SuccessResult();
        }
    }
}