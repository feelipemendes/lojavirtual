using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Application.ViewModels
{
    public class CategoriaEdicaoViewModel
    {
        public int  Id { get; set; }

        [Required(ErrorMessage = "Por favor, insira o nome do Produto.")]
        public string Nome { get; set; }
    }
}
