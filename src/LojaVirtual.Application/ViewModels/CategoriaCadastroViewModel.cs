using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Application.ViewModels
{
    public class CategoriaCadasatroViewModel
    {
        [Required(ErrorMessage = "Por favor, insira o nome do Produto.")]
        public string Nome { get; set; }
    }
}
