using System;
using System.Collections.Generic;
using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Application.Interfaces
{
    public interface ICategoriaService
    {
        void Atualizar(string id, Categoria produto);
        void Detetar(string id);
        void Inserir(Categoria produto);
        List<Categoria> ObterTodos();
        Categoria ObterPorId(string id);
    }
}
