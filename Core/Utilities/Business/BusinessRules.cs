using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    //iş kurallarını burda toplucaz
    public class BusinessRules
    {
               //istediğimiz kadar ıresult parametresi(array) verebiliriz
        public static IResult Run(params IResult[] logics) //ıresult döndürür
        {
            foreach (var logic in logics) //her bir logicsi gezer
            {
                if(!logic.Success)//başarısız ise
                {
                    return logic; //başarısız kuralı direkt gönderiyoruz
                }
            }
            return null; //başarılıysa bir şey döndürmeye gerek yok
        }
    }
}
