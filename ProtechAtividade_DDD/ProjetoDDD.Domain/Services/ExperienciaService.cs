using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Domain.Services
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