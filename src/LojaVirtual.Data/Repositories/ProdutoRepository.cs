using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Data.Context;
using MongoDB.Data.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MongoContext _context;

        public ProdutoRepository(IOptions<DatabaseSettings> settings)
        {
            _context = new MongoContext(settings);
        }

        public void Atualizar(int id, Produto produto)
        {
            try
            {
                _context.Produtos.ReplaceOne(Builders<Produto>.Filter.Eq("Id", id), produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Detetar(int id)
        {
            try
            {
                _context.Produtos.DeleteOne(Builders<Produto>.Filter.Eq("Id", id));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inserir(Produto produto)
        {
            try
            {
                _context.Produtos.InsertOne(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto ObterPorId(int id)
        {
            var filter = Builders<Produto>.Filter.Eq("Id", id);
            try
            {
                return _context.Produtos
                    .Find(filter)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Produto> ObterTodos()
        {
            try
            {
                return _context.Produtos
                    .Find(_ => true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
