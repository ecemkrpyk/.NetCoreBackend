using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //hashi oluşturuyoruz
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
            //ona verilen passwordün hashini ve saltını oluşturacak
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512()) //KULLANILCAK KRİPTOGRAFİ ALGORİTMASI

            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //passwordün byte değerini aldık
            }

        }
        //passwordhashini DOĞRULAMA demek, hashleri doğruluyoruz
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) 

            {
               var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i]) //eşleşmez
                    {
                        return false;
                    }

                }

            }
            return true;

        }
    }
}
