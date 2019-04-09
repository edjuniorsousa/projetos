using ProtechAtividade_DDD.Application.Interface;
using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Services;

namespace ProtechAtividade_DDD.Application
{
    public class PessoaAppService : AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _service;

        public PessoaAppService(IPessoaService service) : base(service)
        {
            _service = service;
        }
    }
}