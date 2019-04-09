using ProtechAtividade_DDD.Application.Interface;
using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Services;

namespace ProtechAtividade_DDD.Application
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