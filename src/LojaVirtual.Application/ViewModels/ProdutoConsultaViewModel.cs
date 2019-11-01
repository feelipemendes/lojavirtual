using LojaVirtual.Domain;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Application.ViewModels
{
    public class ProdutoConsultaViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }        
        public string Descricao { get; set; }        
        public string UrlImagem { get; set; }
        public decimal Preco { get; set; }        
        public string Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string CodigoProduto { get; set; }
    }
}
