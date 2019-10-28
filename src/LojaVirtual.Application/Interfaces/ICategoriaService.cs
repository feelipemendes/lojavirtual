using System;
using System.Collections.Generic;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Application.Interfaces
{
    public interface ICategoriaService
    {
        void Atualizar(int id, Categoria produto);
        void Detetar(int id);
        void Inserir(Categoria produto);
        List<Categoria> ObterTodos();
        Categoria ObterPorId(int id);
    }
}
