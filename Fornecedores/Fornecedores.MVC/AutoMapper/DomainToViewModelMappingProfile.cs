using AutoMapper;
using Fornecedores.Domain.Entities;
using Fornecedores.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fornecedores.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<EmpresaViewModel, Empresa>();
            CreateMap<FornecedorViewModel, Fornecedor>();
        }

        


    }
}