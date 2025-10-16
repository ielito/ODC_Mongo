using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;


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

        public async Task<bool> ValidateConnectionAsync()
        {
            try
            {
                await _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
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

        public async Task<List<BsonDocument>> GetCollectionDocumentsAsync(string collectionName, int skip, int limit)
        {
            var collection = GetCollection(collectionName);
            return await collection.Find(new BsonDocument()).Skip(skip).Limit(limit).ToListAsync();
        }

        //public List<BsonDocument> AggregateCollection(string collectionName, IEnumerable<BsonDocument> pipeline)
        //{
        //    var collection = GetCollection(collectionName);
        //    return collection.Aggregate<BsonDocument>((PipelineDefinition<BsonDocument, BsonDocument>)pipeline).ToList();
        //}

        public async Task<List<BsonDocument>> AggregateCollectionAsync(string collectionName, IEnumerable<BsonDocument> pipelineDocuments)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            try
            {
                var fluent = collection.Aggregate();

                foreach (var stage in pipelineDocuments)
                {
                    fluent = fluent.AppendStage<BsonDocument>(stage);
                }

                var results = await fluent.ToListAsync();

                Console.WriteLine($"Documents aggregated fluently: {results.Count}");
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during fluent aggregation: {ex.Message}");
                return new List<BsonDocument>();
            }
        }

        public async Task CreateDocumentAsync(string collectionName, string documentJson)
        {
            var collection = GetCollection(collectionName);
            var document = BsonDocument.Parse(documentJson);
            await collection.InsertOneAsync(document);
        }

        public async Task<List<BsonDocument>> GetDocumentsAsync(string collectionName, string filterJson)
        {
            var collection = GetCollection(collectionName);
            var filter = BsonDocument.Parse(filterJson);
            return await collection.Find(filter).ToListAsync();
        }

        public async Task UpdateDocumentAsync(string collectionName, string filterJson, string updateJson)
        {
            var collection = GetCollection(collectionName);
            var filter = BsonDocument.Parse(filterJson);
            var update = BsonDocument.Parse(updateJson);
            await collection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteDocumentAsync(string collectionName, string filterJson)
        {
            var collection = GetCollection(collectionName);
            var filter = BsonDocument.Parse(filterJson);
            await collection.DeleteOneAsync(filter);
        }
    }
}
