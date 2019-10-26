using LojaVirtual.Domain;

namespace LojaVirtual.Application.ViewModels
{
    public class ProdutoConsultaViewModel
    {
        
        public string Nome { get; set; }        
        public string Descricao { get; set; }        
        public string UrlImagem { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Preco { get; set; }        
        public string Marca { get; set; }
    }
}
