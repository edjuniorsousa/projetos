using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Domain.Services
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