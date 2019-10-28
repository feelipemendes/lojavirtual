using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LojaVirtual.Domain.Entities
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string CodigoProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }        
        public string IdCategoria { get; set; }
        public decimal Preco { get; set; }
        public string Marca { get; set; }

        #region Relacionamento

        public Categoria Categoria { get; set; }
        #endregion
    }
}
