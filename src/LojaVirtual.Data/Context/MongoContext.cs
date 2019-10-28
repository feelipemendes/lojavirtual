using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Data.Settings;
using LojaVirtual.Domain.Entities;

namespace MongoDB.Data.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.DatabaseName);
            }
        }

        public IMongoCollection<Produto> Produtos
        {
            get
            {
                return _database.GetCollection<Produto>("Produto");
            }
        }

        public IMongoCollection<Categoria> Categorias
        {
            get
            {
                return _database.GetCollection<Categoria>("Categoria");
            }
        }
    }
}
