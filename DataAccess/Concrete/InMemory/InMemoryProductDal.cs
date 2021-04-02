﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal //bütün metodları implemente edicek
    {
        List<Product>  _products;
        public InMemoryProductDal() //contructor
        { 
            //veritabanından veriler geliyormuş gibi simüle ettik 
            _products= new List<Product>  { //içinde birçok ürünü barındırır , ürün listesi
               
                new Product{ProductId=1, CategoryId=1, ProductName="bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="kalvye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="mause", UnitPrice=85, UnitsInStock=1}
            
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
         Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); 
                                                                                            //LINQ kullanımı
                                                                                            //tek bir eleman bulmaya yarar
                                                                                            //her p için productıd leri dolaşır                                                                        //p: o an dolaştığım ürün,product da parametre
            _products.Remove(productToDelete);


        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)//veritabanındaki veriyi businessa vermem lazım
        {
            return _products;  //direkt verileri döndürüyoruz
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün idsine sahip olan listedeki ürünü bul demek
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }

       //public List<Product> GetAllByCategory(int categoryId) //parametre camelCase yazılır

       //{
       //     return _products.Where(p => p.CategoryId == categoryId).ToList(); //liste haline döndürür
       //             //where koşuluna uyanları yeni bir tablo yapar


            
       // }

}
