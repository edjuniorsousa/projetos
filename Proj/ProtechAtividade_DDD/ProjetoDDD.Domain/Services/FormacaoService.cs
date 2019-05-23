using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Domain.Services
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