using AutoMapper;
using ProjetoDDD.Application.ViewModels;
using ProjetoDDD.Domain.Entities;
using ProjetoModelo_MVC.ViewModels;

namespace ProjetoDDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteLivroViewModel, Cliente>();
            CreateMap<LivroViewModel, Livro>();
            CreateMap<ClienteLivroViewModel, Livro>();
        }
    }
}