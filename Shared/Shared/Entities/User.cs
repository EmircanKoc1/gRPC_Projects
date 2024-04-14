

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement(Order =0)]
        public string Id { get; set; } 

        [BsonRepresentation(BsonType.String)]
        [BsonElement(Order =1)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement(Order =2)]
        public string Surname { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        [BsonElement(Order =3)]
        public int Age { get; set; }
        public ICollection<Task> Tasks{ get; set; } = new List<Task>();
        public Credential Credential { get; set; } = new();
        public Contact Contact { get; set; } = new();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
