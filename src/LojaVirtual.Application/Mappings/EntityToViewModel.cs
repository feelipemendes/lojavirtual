using AutoMapper;
using LojaVirtual.Application.ViewModels;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Application.Mappings
{
    public class EntityToViewModel : Profile
    {
        public EntityToViewModel()
        {
            CreateMap<Produto, ProdutoConsultaViewModel>();
            CreateMap<Categoria, CategoriaConsultaViewModel>();
        }
    }
}
