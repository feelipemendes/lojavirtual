using System;
using System.Collections.Generic;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        
            void Atualizar(string id, Categoria categoria);
            void Detetar(string id);
            void Inserir(Categoria categoria);
            List<Categoria> ObterTodos();
            Categoria ObterPorId(string id);
        
    }
}
