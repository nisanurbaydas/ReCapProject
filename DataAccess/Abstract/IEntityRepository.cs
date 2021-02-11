using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // Generic Constraint
    // T, newlenebilir bir IEntity sınıfı olmalı
    // IEntity olamaz
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //çekeceğin verilere filtre getirebilmek için expression kullandın
        //filter = null -> filtre vermeyedebiilirsin
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
