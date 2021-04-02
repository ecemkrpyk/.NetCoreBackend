using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //productla ilgili veritabanında yapacağım operasyonları içeren interface
    public interface IProductDal: IEntityRepository<Product> //çalışma şekli product 
    {

        List<ProductDetailDto> GetProductDetail();
    }
}
