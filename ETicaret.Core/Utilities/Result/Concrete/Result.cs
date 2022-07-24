using ETicaret.Core.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.Utilities.Concrete
{
    public class Result :IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
    }
}
