﻿using AutoMapper;
using Fornecedores.Domain.Entities;
using Fornecedores.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fornecedores.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<Fornecedor, FornecedorViewModel>();
        }
    }
}