

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public ICollection<Task> Tasks{ get; set; } = new List<Task>();
        public Credential Credential { get; set; } = new();
        public Contact Contact { get; set; } = new();
        public ICollection<Address> Addresses { get; set; }
    }
}
