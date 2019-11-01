using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;

namespace LojaVirtual.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoService(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public void Atualizar(string id, Produto produto)
        {
            _produtoRepository.Atualizar(id, produto);
        }

        public void Detetar(string id)
        {
            _produtoRepository.Detetar(id);
        }

        public void Inserir(Produto produto)
        {
            try
            {
                var categoria = _categoriaRepository.ObterPorId(produto.IdCategoria);
                _produtoRepository.Inserir(produto);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Message);
            }
        }       

        public Produto ObterPorId(string id)
        {

            var produto = _produtoRepository.ObterPorId(id);

            if (produto != null)
            {
                var categoria = _categoriaRepository.ObterPorId(produto.IdCategoria);

                if (categoria != null)
                {
                    produto.Categoria = categoria;
                }
            }

            return produto;
        }

        public List<Produto> ObterTodos()
        {
            var resultProdutos = new List<Produto>();

            var produtos = _produtoRepository.ObterTodos();

            if (produtos.Any())
            {
                foreach (var produto in produtos)
                {
                    var categoria = _categoriaRepository.ObterPorId(produto.IdCategoria);

                    if (categoria != null)
                    {
                        produto.Categoria = categoria;
                    }

                    resultProdutos.Add(produto);
                }
            }

            return resultProdutos;
        }
    }
}
