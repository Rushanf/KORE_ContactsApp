using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }

        protected Result (bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Ok()
        {
            return new Result(true,"");
        }
        public static Result Fail(string message)
        {
            return new Result(false, message);
        }
    }
}
