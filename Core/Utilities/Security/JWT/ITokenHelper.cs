using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //veritabanından claimlere bakacak
        //ilgili kullanıcıların claimlerini içeren token üretecek
        AccessToken CreateToken(User user, List<OperationClaims> operationClaims);
      
    }
}
