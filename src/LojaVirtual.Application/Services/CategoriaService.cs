using System;
using System.Collections.Generic;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;

namespace LojaVirtual.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public void Atualizar(string id, Categoria categoria)
        {
            _repository.Atualizar(id, categoria);
        }

        public void Detetar(string id)
        {
            _repository.Detetar(id);
        }

        public void Inserir(Categoria categoria)
        {
            _repository.Inserir(categoria);
        }

        public Categoria ObterPorId(string id)
        {
            return _repository.ObterPorId(id);
        }

        public List<Categoria> ObterTodos()
        {
            return _repository.ObterTodos();
        }
    }
}
