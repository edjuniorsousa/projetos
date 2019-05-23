using ProtechDDD.Dominio.Entities;
using ProtechDDD.Dominio.Interfaces.Repositories;
using ProtechDDD.Dominio.Interfaces.Services;

namespace ProtechDDD.Dominio.Services
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
