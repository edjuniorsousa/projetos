using ProtechAtividade_DDD.Application.Interface;
using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Services;

namespace ProtechAtividade_DDD.Application
{
    public class ExperienciaAppService : AppServiceBase<Experiencia>, IExperienciaAppService
    {
        private readonly IExperienciaService _service;

        public ExperienciaAppService(IExperienciaService service) : base(service)
        {
            _service = service;
        }
    }
}