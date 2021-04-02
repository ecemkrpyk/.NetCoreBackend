using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>: DataResult<T>
    {                                                   //tüm bilgiler verilir
        public SuccessDataResult(T data, string message):base(data,true,message)
        {

        }
        //MESAJ İSTEMEZSE
        public SuccessDataResult(T data) :base(data,true)
        {

        }
        //sadece mesaj veririz, datanın default hali
        public SuccessDataResult(string message):base(default,true,message)
        {

        }
        //hiç birşey vermeyiz
        public SuccessDataResult() :base(default,true)
        {

        }
    }
}
