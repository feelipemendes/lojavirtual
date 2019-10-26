namespace LojaVirtual.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string CodigoProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }        
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Marca { get; set; }

    }
}
