using LojaVirtual.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Atualizar(string id, Produto produto);
        void Detetar(string id);
        void Inserir(Produto produto);
        List<Produto> ObterTodos();
        Produto ObterPorId(string id);
    }
}
