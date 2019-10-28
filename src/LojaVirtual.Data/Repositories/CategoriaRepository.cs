using LojaVirtual.Domain.Entities;
using LojaVirtual.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Data.Context;
using MongoDB.Data.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MongoContext _context;

        public CategoriaRepository(IOptions<DatabaseSettings> settings)
        {
            _context = new MongoContext(settings);
        }

        public void Atualizar(int id, Categoria categoria)
        {
            try
            {
                _context.Categorias.ReplaceOne(Builders<Categoria>.Filter.Eq("Id", id), categoria);
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
                _context.Categorias.DeleteOne(Builders<Categoria>.Filter.Eq("Id", id));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inserir(Categoria categoria)
        {
            try
            {
                _context.Categorias.InsertOne(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categoria ObterPorId(int id)
        {
            var filter = Builders<Categoria>.Filter.Eq("Id", id);
            try
            {
                return _context.Categorias
                    .Find(filter)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Categoria> ObterTodos()
        {
            try
            {
                return _context.Categorias
                    .Find(_ => true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
