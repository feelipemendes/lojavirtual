using System.Collections.Generic;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;

namespace LojaVirtual.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        protected readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public void Atualizar(int id, Produto produto)
        {
            _repository.Atualizar(id, produto);
        }

        public void Detetar(int id)
        {
            _repository.Detetar(id);
        }

        public void Inserir(Produto produto)
        {
            _repository.Inserir(produto);
        }

        public Produto ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public List<Produto> ObterTodos()
        {
            return _repository.ObterTodos();
        }
    }
}
