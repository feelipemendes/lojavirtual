using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Application.ViewModels
{
    public class CategoriaConsultaViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Por favor, insira o nome do Produto.")]
        public string Nome { get; set; }
    }
}
