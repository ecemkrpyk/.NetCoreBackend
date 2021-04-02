using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //doğrulama kurallarını yapıcaz
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //kim için kural yazıcaksak
            RuleFor(p => p.ProductName).NotEmpty(); //boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2); //productname 2 karakter olmalıdır
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); //o dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //.withmessage ile hata mesajı verebiliriz
            //olmayan birşeyi yazmak istersek
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("ürünler A harfi ile başlamalı");
            //must uymalı demek,startwitha da kendi yazacağımız metod


        }

        private bool StartWithA(string arg) //böylece kendi kuralımızın metodunu yazabiliriz
        {//arg productname aslında

            return arg.StartsWith("A"); 
        }//false dönerse patlar
    }
}
