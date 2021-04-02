using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // IResultun somut sınıfı
    public class Result : IResult
    {
        

        //constructer
        public Result(bool success, string message):this(success) //böylelikle her iki resultta çalışmış olur
        {                                           //tek parametreli classıda çalıştır
            Message = message; //nasıl set ettik hani sadece get 

        }
        public Result(bool success) //her ikisini de karşılayabilir-overloading
        {
            Success = success;

        }
        public bool Success { get; }

        public string Message { get; }
    }
}
