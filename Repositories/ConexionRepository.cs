using RutaCampus.Algortimos;
using RutaCampus.Common;
using RutaCampus.Contratos;
using System.Collections.Generic;
using System.IO;

namespace RutaCampus.Repositories
{
    internal sealed class ConexionRepository : Singleton<ConexionRepository>, IRepository<Conexion, int>
    {
        private readonly Repository<Conexion, int> _repository;

        private ConexionRepository()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Datos", "Conexiones.txt");
            _repository = new Repository<Conexion, int>(path);
        }

        public void Add(Conexion obj) => _repository.Add(obj);
        public void Update(Conexion obj) => _repository.Update(obj);
        public void Delete(int id) => _repository.Delete(id);
        public bool Exist(int id) => _repository.Exist(id);
        public Conexion GetById(int id) => _repository.GetById(id);
        public IEnumerable<Conexion> GetAll() => _repository.GetAll();
        public bool IsEmpty() => _repository.IsEmpty();
        public void commit() => _repository.commit();
    }
}
