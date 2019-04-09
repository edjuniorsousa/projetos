using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Domain.Interfaces.Repositories;
using ProtechAtividade_DDD.Domain.Interfaces.Services;

namespace ProtechAtividade_DDD.Domain.Services
{
    public class ExperienciaEmpresaService : ServiceBase<ExperienciaEmpresa>, IExperienciaEmpresaService
    {
        private readonly IExperienciaEmpresaRepository _repository;

        public ExperienciaEmpresaService(IExperienciaEmpresaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
