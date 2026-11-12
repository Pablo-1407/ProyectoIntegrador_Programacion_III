using RutaCampus.Common;
using RutaCampus.Contratos;
using RutaCampus.Domain;
using System.Collections.Generic;
using System.IO;

namespace RutaCampus.Repositories
{
    internal sealed class ContenedoresRepository : Singleton<ContenedoresRepository>, IRepository<Contenedores, int>
    {
        private readonly Repository<Contenedores, int> _repository;

        private ContenedoresRepository()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Datos", "Contenedores.txt");
            _repository = new Repository<Contenedores, int>(path);
        }

        public void Add(Contenedores obj) => _repository.Add(obj);
        public void Update(Contenedores obj) => _repository.Update(obj);
        public void Delete(int id) => _repository.Delete(id);
        public bool Exist(int id) => _repository.Exist(id);
        public Contenedores GetById(int id) => _repository.GetById(id);
        public IEnumerable<Contenedores> GetAll() => _repository.GetAll();
        public bool IsEmpty() => _repository.IsEmpty();
        public void commit() => _repository.commit();
    }
}
