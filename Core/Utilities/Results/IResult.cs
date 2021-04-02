using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // temel voidler için başlangıç
    public interface IResult
    {
       //ekleme işi başarılı mı başarısız mı 
        bool Success { get; } //sadece okunabilir demek-get
                              //set yazmak için
        string Message { get; }


    }
}
