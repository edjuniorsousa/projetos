using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Repositories;
using ProtechAtividade_DDD.Domain.Interfaces.Services;

namespace ProtechAtividade_DDD.Domain.Services
{
    public class FormacaoService : ServiceBase<Formacao>, IFormacaoService
    {
        private readonly IFormacaoRepository _repository;

        public FormacaoService(IFormacaoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}