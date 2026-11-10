using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Contratos
{
    internal interface IRepository<T, TId> where T : class, IFactory<T>, IDentity<TId>, ISerialize<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(TId id);
        bool Exist(TId id);
        T GetById(TId id);
        IEnumerable<T> GetAll();
    }
}
