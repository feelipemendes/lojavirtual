using LojaVirtual.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Application.Interfaces
{
    public interface IProdutoService
    {
        void Atualizar(string id, Produto produto);
        void Detetar(string id);
        void Inserir(Produto produto);
        List<Produto> ObterTodos();
        Produto ObterPorId(string id);
    }
}
