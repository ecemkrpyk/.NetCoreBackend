using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //context: db classları ile proje classlarını bağlamak
    public class NorthwindContext: DbContext //entityframeworkcore da base classtır
    {
        //hangi veritabanı ile ilşkiyi belirteceğimiz kısım
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                          //sqlserver kullanıcaz demek, nereye  bağlanacağını gösterdik
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true"); 
                                          //db nin yeri          hangi db           kullanıcı adı şifresiz bağlanmak için

        }
        //hangi nesnem hangi nesneye karşılık geleceğini burda yaparız
        public DbSet <Product> Products { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaims> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    }
}
