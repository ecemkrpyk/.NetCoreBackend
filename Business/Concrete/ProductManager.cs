using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService; //dal enjekte edemeyiz 
        public ProductManager(IProductDal productDal, ICategoryService categoryService)  //erişim alternatifleri
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        [SecuredOperation("product.add,admin")] //korunan operasyon--yetkilendirme, rolleri virgül ile verebiliriz

        [ValidationAspect(typeof(ProductValidator))] //attribute oluyor, typeof ile tipi veririz
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {

            //iş kodu, validation kodu aspectte yapıcaz           
           
            IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                    CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                    CheckIfCategoryLımıtExceded());
                    //kurallar buraya eklenir

            if (result != null) //kurala uymayan durum
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); //kurallara uyuyorsa eklenir                   
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları varsa yazılır
            //yetkisi var mı vs diye kodlar
            if (DateTime.Now.Hour == 22) //saat 22 ye kadar sistemi kapatmak istiyoruz(saat kaçsa onu yazabilirsin
            {                                                      //bakım zamanı demek
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
         
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id)); //id8ye eşitse alacak

        }

        [CacheAspect]
        [PerformanceAspect(5)] //bu metodun çalışması 5 saniyeyi geçerse beni uyar
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
                                      //2 fiyat aralığını getirir
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetail());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")] //ıproductservice içersindeki getleri uçur demek
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductOfCategoryCountError);
            }
            throw new NotImplementedException();
        }

        //kategorideki ürün sayısını kurallara uygunluğunu doğrula
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //bir kategoride en fazla 10 ürün olabilir--business code örneği
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductOfCategoryCountError);
            }
            return new SuccessResult();
        }

        //aynı isimde ürün eklenemez
        private IResult CheckIfProductNameExists(string productName)
        {
            //bir kategoride en fazla 10 ürün olabilir--business code örneği
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //any var mı demek
            if (result) //böyle bir data varsa 
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists); //böyle ürün ismi zaten var demek
            }
            return new SuccessResult();
        }

        //eğer mevcut kategorideki ürün sayısı 15 i geçtiyse sisteme yeni ürün eklenemez
        private IResult CheckIfCategoryLımıtExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLımıtExceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice<10)
            {
                throw new Exception("");
            }
            Add(product);
            return null;
        }
    }
}






