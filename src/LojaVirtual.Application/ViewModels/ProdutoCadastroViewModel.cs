using LojaVirtual.Domain;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Application.ViewModels
{
    public class ProdutoCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, insira o nome do Produto.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, insira a descrição do Produto.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, insira a imagem do Produto.")]
        public string UrlImagem { get; set; }

        [Required(ErrorMessage = "Por favor, insira a categoria do Produto.")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Por favor, insira o preço do Produto.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Por favor, insira a marca do Produto.")]
        public string Marca { get; set; }
    }
}
