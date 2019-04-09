using ProtechAtividade_DDD.Application.Interface;
using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Services;

namespace ProtechAtividade_DDD.Application
{
    public class FormacaoAppService : AppServiceBase<Formacao>, IFormacaoAppService
    {
        private readonly IFormacaoService _service;

        public FormacaoAppService(IFormacaoService service) : base(service)
        {
            _service = service;
        }
    }
}