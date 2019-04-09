using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Repositories;
using ProtechAtividade_DDD.Domain.Interfaces.Services;

namespace ProtechAtividade_DDD.Domain.Services
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