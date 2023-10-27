using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDB_ODC
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;

        public MongoService(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public bool ValidateConnection()
        {
            try
            {
                _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to database: {ex.Message}");
                return false;
            }
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return _database.GetCollection<BsonDocument>(collectionName);
        }

        public bool CollectionExists(string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var collections = _database.ListCollections(new ListCollectionsOptions { Filter = filter });
            return collections.Any();
        }

        public long GetDocumentCount(string collectionName)
        {
            var collection = GetCollection(collectionName);
            return collection.CountDocuments(new BsonDocument());
        }
    }
}
