using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Application
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