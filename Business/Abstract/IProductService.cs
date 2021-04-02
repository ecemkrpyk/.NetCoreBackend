using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //iş katmanında kullanacağımız servis operasyonları
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //bunun içine data da koymuş olucaz
        IDataResult<List<Product>> GetAllByCategoryId(int id); //idye göre getiricez
        IDataResult<List<Product>> GetByUnitPrice(decimal min,decimal max); //şu fiyat aralığında olanları getir diyeceğiz

        IDataResult<List<ProductDetailDto>> GetProductDetail();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product); //ıresult void
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);





    }
}
