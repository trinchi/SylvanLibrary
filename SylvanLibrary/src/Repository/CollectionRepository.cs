using System.Collections.Generic;
using MongoDB.Driver;
using SylvanLibrary.Config;
using SylvanLibrary.Model;

namespace SylvanLibrary.Repository
{
    public class CollectionRepository
    {
        private readonly IMongoCollection<Collection> _collections;

        public CollectionRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collections = database.GetCollection<Collection>(settings.CollectionCollectionName);
        }

        public List<Collection> Get() =>
            _collections.Find(collection => true).ToList();

        public Collection Get(string id) =>
            _collections.Find<Collection>(collection => collection.Id == id).FirstOrDefault();

        public Collection Create(Collection collection)
        {
            _collections.InsertOne(collection);
            return collection;
        }

        public void Update(string id, Collection collectionIn) =>
            _collections.ReplaceOne(collection => collection.Id == id, collectionIn);

        public void Remove(Collection collectionIn) =>
            _collections.DeleteOne(collection => collection.Id == collectionIn.Id);

        public void Remove(string id) => 
            _collections.DeleteOne(collection => collection.Id == id);
    }
}