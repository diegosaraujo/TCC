using AutoMapper;
using ProjetoDDD.Application.ViewModels;
using ProjetoDDD.Domain.Entities;
using ProjetoModelo_MVC.ViewModels;

namespace ProjetoDDD.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cliente, ClienteLivroViewModel>();
            CreateMap<Livro, LivroViewModel>();
            CreateMap<Livro, ClienteLivroViewModel>();
        }
    }
}