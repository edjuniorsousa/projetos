using Ninject;
using ProjetoDDD.Application;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Domain.Interfaces.Services;
using ProjetoDDD.Domain.Services;
using ProjetoDDD.Infra.Data.Repositories;

namespace ProjetoDDD.Infra.CrossCutting.Ioc
{
    public class RegisterServices
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
