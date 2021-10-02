using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SylvanLibrary.Model
{
    public class Collection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }

        public Card Card { get; set; }
    }
}