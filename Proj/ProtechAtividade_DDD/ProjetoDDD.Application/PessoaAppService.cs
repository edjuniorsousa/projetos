using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Application
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