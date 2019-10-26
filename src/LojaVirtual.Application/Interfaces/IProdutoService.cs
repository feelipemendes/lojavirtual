using LojaVirtual.Domain.Entities;
using System.Collections.Generic;

namespace LojaVirtual.Application.Interfaces
{
    public interface IProdutoService
    {
        void Atualizar(int id, Produto produto);
        void Detetar(int id);
        void Inserir(Produto produto);
        List<Produto> ObterTodos();
        Produto ObterPorId(int id);
    }
}
