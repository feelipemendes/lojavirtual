using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LojaVirtual.Domain.Entities
{
    public class Categoria
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }


    }
}
