using ProtechDDD.Dominio.Entities;
using ProtechDDD.Dominio.Interfaces.Repositories;
using ProtechDDD.Dominio.Interfaces.Services;

namespace ProtechDDD.Dominio.Services
{
    public class ExperienciaService : ServiceBase<Experiencia>, IExperienciaService
    {
        private readonly IExperienciaRepository _repository;

        public ExperienciaService(IExperienciaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}