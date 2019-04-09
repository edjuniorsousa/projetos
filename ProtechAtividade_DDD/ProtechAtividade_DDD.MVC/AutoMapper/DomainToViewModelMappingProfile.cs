using AutoMapper;
using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.MVC.ViewModels;

namespace ProtechAtividade_DDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PessoaViewModel, Pessoa>();
            //CreateMap<ExperienciaViewModel, Experiencia>();
            //CreateMap<ExperienciaEmpresaViewModel, ExperienciaEmpresa>();
            //CreateMap<FormacaoViewModel, Formacao>();
        }
        /* public override string ProfileName
         {
             get { return "DomainToViewModelMapping"; }
         }

         /*protected override void Configure()
         {
             Mapper.CreateMap<PessoaViewModel, Pessoa>();
             Mapper.CreateMap<ExperienciaViewModel, Experiencia>();

         }*/
    }
}