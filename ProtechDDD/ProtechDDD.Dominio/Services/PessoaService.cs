using ProtechDDD.Dominio.Entities;
using ProtechDDD.Dominio.Interfaces.Repositories;
using ProtechDDD.Dominio.Interfaces.Services;

namespace ProtechDDD.Dominio.Services
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}