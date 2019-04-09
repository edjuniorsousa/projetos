using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Repositories;
using ProtechAtividade_DDD.Domain.Interfaces.Services;

namespace ProtechAtividade_DDD.Domain.Services
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