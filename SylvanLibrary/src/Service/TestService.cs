using Microsoft.Extensions.Caching.Distributed;
using SylvanLibrary.Model;
using SylvanLibrary.Repository;

namespace SylvanLibrary.Service
{
    public class TestService
    {
        private readonly CollectionRepository _collectionRepo;
        private readonly IDistributedCache _cache;
        
        public TestService(CollectionRepository collectionRepo, IDistributedCache cache)
        {
            _collectionRepo = collectionRepo;
            _cache = cache;
        }

        public Card test()
        {
            var foo = new Collection()
            {
                Card = new Card()
                {
                    Name = "CARD NAME"
                }
            };

            var hello = _collectionRepo.Create(foo);

            var bar = _collectionRepo.Get();
            
            return hello.Card;
        }
    }
}