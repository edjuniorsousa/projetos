using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Application
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