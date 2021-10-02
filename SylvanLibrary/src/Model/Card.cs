using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SylvanLibrary.Model
{
    public class Card
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Name { get; set; }
    }
}