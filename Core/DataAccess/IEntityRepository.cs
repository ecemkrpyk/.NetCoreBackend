using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess //proje ismi ve klasör ismi


    //new() newlenebilir olmalı demek
{                                      //generic
    public interface IEntityRepository<T> where T:class,IEntity,new()  //T yi sınrılandırmak istiyoruz yani herkes istediği T yi yazamasın
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        
    }
}
