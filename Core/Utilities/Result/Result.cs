using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result(bool succes, string message) :this(succes)
        {
           this.Message = message;
            
        }

        public Result( bool succes)
        {
           this.Success = succes;
        }
        public string Message { get;  }

        public bool Success { get; }
    }
}
