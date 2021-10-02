using SylvanLibrary.Model;
using SylvanLibrary.Repository;

namespace SylvanLibrary.Config
{
    public class Query
    {
        private readonly CollectionRepository _collectionRepo;
        
        public Query(CollectionRepository collectionRepo)
        {
            this._collectionRepo = collectionRepo;
        }
        
        public Collection GetCollection() =>
            new Collection
            {
                Title = "C# in depth.",
                Card = new Card()
                {
                    Name = "Jon Skeet"
                }
            };
    }
}