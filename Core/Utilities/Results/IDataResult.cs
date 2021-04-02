using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{              //hangi tipi döndüreceğini(çalışacağını) bana söyle----generic
    public interface IDataResult<T>: IResult
    {      //succes ve mesaj dışında data da olacak

        T Data { get; }


    }
}
