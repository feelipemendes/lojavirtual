using LojaVirtual.Domain.Entities;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Atualizar(int id, Produto produto);
        void Detetar(int id);
        void Inserir(Produto produto);
        List<Produto> ObterTodos();
        Produto ObterPorId(int id);
    }
}
