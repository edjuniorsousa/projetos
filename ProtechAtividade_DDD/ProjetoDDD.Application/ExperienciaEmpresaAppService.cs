using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Application
{
    public class ExperienciaEmpresaAppService : AppServiceBase<ExperienciaEmpresa>, IExperienciaEmpresaAppService
    {
        private readonly IExperienciaEmpresaService _service;

        public ExperienciaEmpresaAppService(IExperienciaEmpresaService service) : base(service)
        {
            _service = service;
        }
    }
}