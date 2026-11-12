using RutaCampus.Common;
using RutaCampus.Contratos;
using RutaCampus.Domain;
using System.Collections.Generic;
using System.IO;

namespace RutaCampus.Repositories
{
    internal sealed class AcopioRepository : Singleton<AcopioRepository>, IRepository<Acopio, int>
    {
        private readonly Repository<Acopio, int> _repository;

        private AcopioRepository()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Datos", "Acopio.txt");
            _repository = new Repository<Acopio, int>(path);
        }

        public void Add(Acopio obj) => _repository.Add(obj);
        public void Update(Acopio obj) => _repository.Update(obj);
        public void Delete(int id) => _repository.Delete(id);
        public bool Exist(int id) => _repository.Exist(id);
        public Acopio GetById(int id) => _repository.GetById(id);
        public IEnumerable<Acopio> GetAll() => _repository.GetAll();
        public bool IsEmpty() => _repository.IsEmpty();
        public void commit() => _repository.commit();
    }
}
