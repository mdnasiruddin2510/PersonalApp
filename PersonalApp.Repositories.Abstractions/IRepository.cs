using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalApp.Repositories.Abstractions
{
    public interface IRepository<T> where T:class
    {
        T GetById(int id);
        ICollection<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
       
        
    }
}
