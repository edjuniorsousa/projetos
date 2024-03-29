﻿using AutoMapper;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.MVC.ViewModels;

namespace ProjetoDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>();
            //CreateMap<Experiencia, ExperienciaViewModel>();
            //CreateMap<ExperienciaEmpresa, ExperienciaEmpresaViewModel>();
            //CreateMap<Formacao, FormacaoViewModel>();
        }
        /*public override string ProfileName
        {
            get { return "DomainToViewModelMapping"; }
        }

        /*protected override void Configure()
        {
            Mapper.CreateMap<Pessoa, PessoaViewModel>();
            Mapper.CreateMap<Experiencia, ExperienciaViewModel>();
        }*/
    }
}