using Ninject;
using ProtechAtividade_DDD.Application;
using ProtechAtividade_DDD.Application.Interface;
using ProtechAtividade_DDD.Domain.Interfaces.Repositories;
using ProtechAtividade_DDD.Domain.Interfaces.Services;
using ProtechAtividade_DDD.Domain.Services;
using ProtechAtividade_DDD.Infra.Data.Repositories;

namespace ProtechAtividade_DDD.Infra.CrossCutting.Ioc
{
    class RegisterServices
    {
        public RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IPessoaAppService>().To<PessoaAppService>();
            kernel.Bind<IExperienciaAppService>().To<ExperienciaAppService>();
            kernel.Bind<IExperienciaEmpresaAppService>().To<ExperienciaEmpresaAppService>();
            kernel.Bind<IFormacaoAppService>().To<FormacaoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IPessoaService>().To<PessoaService>();
            kernel.Bind<IExperienciaService>().To<ExperienciaService>();
            kernel.Bind<IExperienciaEmpresaService>().To<ExperienciaEmpresaService>();
            kernel.Bind<IFormacaoService>().To<FormacaoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IPessoaRepository>().To<PessoaRepository>();
            kernel.Bind<IExperienciaRepository>().To<ExperienciaRepository>();
            kernel.Bind<IExperienciaEmpresaRepository>().To<ExperienciaEmpresaRepository>();
            kernel.Bind<IFormacaoRepository>().To<FormacaoRepository>();
        }
    }
}
