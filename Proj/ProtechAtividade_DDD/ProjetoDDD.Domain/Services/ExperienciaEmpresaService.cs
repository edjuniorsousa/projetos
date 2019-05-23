using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Domain.Interfaces.Services;

namespace ProjetoDDD.Domain.Services
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
