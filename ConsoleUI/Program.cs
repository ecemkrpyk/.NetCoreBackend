using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {

            //hangi veri yöntemi ile çalıştığını söylemen lazım
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetail();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {                                      //yazdığımız tüm metodları kullanabiliriz, getall, getbyunitprice vs..

                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }


    }
}
