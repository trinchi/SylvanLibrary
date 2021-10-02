using AutoFixture;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SylvanLibrary.Config;
using SylvanLibrary.Model;
using SylvanLibrary.Repository;
using SylvanLibrary.Service;
using Xunit;

namespace SylvanLibrary.Tests
{
    public class UnitTest1
    {
        private readonly TestService _service;
        private readonly Fixture _fixture;

        public UnitTest1()
        {
            var cacheSettings = Options.Create(new MemoryDistributedCacheOptions());

            var databaseSettings = new SylvanLibraryDatabaseSettings()
            {
                CollectionCollectionName = "Collection",
                ConnectionString = "mongodb://root:example@localhost:27017",
                DatabaseName = "SylvanLibrary"
            };
            _service = new TestService(
                new CollectionRepository(databaseSettings),
                new MemoryDistributedCache(cacheSettings));
            _fixture = new Fixture();
        }

        [Fact]
        public void Test1()
        {
            var card = _fixture.Create<Card>();
            _service.test();
        }
    }
}