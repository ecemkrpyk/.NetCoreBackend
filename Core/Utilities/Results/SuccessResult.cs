using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public  class SuccessResult: Result //base result oluyor
    {
        public SuccessResult(string message) : base(true, message)
        {

        }
        public SuccessResult() : base(true) //mesaj vermeden true
        {

        }
    }
}
