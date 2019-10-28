using System;
using System.Collections.Generic;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        
            void Atualizar(int id, Categoria categoria);
            void Detetar(int id);
            void Inserir(Categoria categoria);
            List<Categoria> ObterTodos();
            Categoria ObterPorId(int id);
        
    }
}
