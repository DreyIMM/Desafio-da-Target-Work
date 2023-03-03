using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Infrastructure.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<ClientViewModel, Client>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();


        }
    }
}
