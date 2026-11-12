using RutaCampus.Common;
using RutaCampus.Contratos;
using RutaCampus.Domain;
using System.Collections.Generic;
using System.IO;

namespace RutaCampus.Repositories
{
    internal sealed class UsuarioRepository : Singleton<UsuarioRepository>, IRepository<Usuario, long>
    {
        private readonly Repository<Usuario, long> _repository;

        private UsuarioRepository()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Datos", "Usuario.txt");
            _repository = new Repository<Usuario, long>(path);
        }

        public void Add(Usuario obj) => _repository.Add(obj);
        public void Update(Usuario obj) => _repository.Update(obj);
        public void Delete(long id) => _repository.Delete(id);
        public bool Exist(long id) => _repository.Exist(id);
        public Usuario GetById(long id) => _repository.GetById(id);
        public IEnumerable<Usuario> GetAll() => _repository.GetAll();
        public bool IsEmpty() => _repository.IsEmpty();
        public void commit() => _repository.commit();
    }
}
