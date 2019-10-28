using AutoMapper;
using LojaVirtual.Application.ViewModels;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Application.Mappings
{
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<ProdutoCadastroViewModel, Produto>();
            CreateMap<ProdutoEdicaoViewModel, Produto>();
            CreateMap<CategoriaEdicaoViewModel, Categoria>();
            CreateMap<CategoriaCadasatroViewModel, Categoria>();
        }
    }
}
