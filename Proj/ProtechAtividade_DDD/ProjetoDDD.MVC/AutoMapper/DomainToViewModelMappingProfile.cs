using AutoMapper;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.MVC.ViewModels;

namespace ProjetoDDD.MVC.AutoMapper
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