using System.Collections.Generic;

namespace App.Models.Repositorios
{
    interface IRepositorio<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        T Get(int id);
        IList<T> GetAll();         
    }
}
