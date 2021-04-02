using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //erişim anahtarı olarak geçer
    public class AccessToken
    {
        public string Token { get; set; }        //jwt deki tokenın kendisi
        public DateTime Expiration { get; set; } //tokenın bitiş zamanı
    }
}
