using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAppStartupOne.Services
{
    public interface IService<T> where T : new()
    {
        IEnumerable<T> GetAll();
        T Insert(T model);
        T Update(T model);
        void Delete(T model);
    }
}
