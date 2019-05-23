using ProtechDDD.Dominio.Entities;
using ProtechDDD.Dominio.Interfaces.Repositories;
using ProtechDDD.Dominio.Interfaces.Services;

namespace ProtechDDD.Dominio.Services
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