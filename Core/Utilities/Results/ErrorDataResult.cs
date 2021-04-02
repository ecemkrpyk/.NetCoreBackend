using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
     
    public class ErrorDataResult<T> : DataResult<T>
    {                                                   //tüm bilgiler verilir
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //MESAJ İSTEMEZSE
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //sadece mesaj veririz, datanın default hali
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        //hiç birşey vermeyiz
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
