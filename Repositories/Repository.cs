using RutaCampus.Common;
using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Repositories
{
    internal class Repository<T, TId> : IRepository<T, TId>, IDentity<int>, IUnidOfWork where T : class, IFactory<T>, IDentity<TId>, ISerialize<T>
    {
        private DataStore<T> _dataStore;
        private DoubleLinkList<T> _list;
        public Repository(string path)
        {
            _dataStore = new DataStore<T>(path);
            _list = new DoubleLinkList<T>();
            foreach (T item in _dataStore.GetAll())
            {
                Add(item);
            }
        }

        public int Id { get; set;}

        public void Add(T obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            if (Exist(obj.Id))
            {
                Update(obj);
                return;
            }

            _list.Add(obj);
        }

        public void commit()
        {
            _dataStore.SaveAll(_list);
        }

        public void Delete(TId id)
        {
            _list.Delete(GetPositionById(id));
        }

        public bool Exist(TId id)
        {
            try
            {
                GetPositionById(id);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _list;
        }

        public T GetById(TId id)
        {
            return _list.ElementAt(GetPositionById(id))!;
        }

        public void Update(T obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            _list[GetPositionById(obj.Id)] = obj;
        }

        private int GetPositionById(TId id)
        {
            int position = 0;
            foreach (T item in _list)
            {
                if (EqualityComparer<TId>.Default.Equals(item.Id, id))
                {
                    return position;
                }
                position++;
            }
            throw new ArgumentException("El elemento no se encuentra en la lista.", nameof(id));
        }
    }
}
