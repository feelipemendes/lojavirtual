using LojaVirtual.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Application.ViewModels
{
    public class ProdutoEdicaoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, insira o nome do Produto.")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, insira a descrição do Produto.")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, insira a imagem do Produto.")]
        [DisplayName("Imagem")]
        public string UrlImagem { get; set; }

        [Required(ErrorMessage = "Por favor, insira a categoria do Produto.")]
        [DisplayName("Categoria")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Por favor, insira o preço do Produto.")]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Por favor, insira a marca do Produto.")]
        [DisplayName("Marca")]
        public string Marca { get; set; }
    }
}
