using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity>

        where TEntity: class, IEntity, new()
        where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation
            using (TContext context = new TContext()) //nortwindcontext bellek de işi bitince direkt atılacak demek, belleği hızlıca temizler
            {
                //eklenen değişken demek
                var addedEntity = context.Entry(entity); //veriyi aldı,REFERANSI YAKALA
                addedEntity.State = EntityState.Added;         //gelen veriyi ne yapalım, EKLE
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var deletededEntity = context.Entry(entity);
                deletededEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter)//tek data getirir
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {


            using (TContext context = new TContext())
            {
                //select *from products döndürür arka planda
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //filtre yoksa tüm veriyi getirir, filtre varsa bir where koşulu yazıcaz
                //filtera ne yazarsan yaz o datayı bize getirir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
