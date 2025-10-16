using MongoDB.Bson;
using MongoDB.Driver;
using OutSystems.ExternalLibraries.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Core.Configuration;

namespace MongoDB_ODC
{
    public class MyLibrary : IMongoDB
    {
        private MongoService _mongoService;

        public MyLibrary()
        {
        
        }

        public void Initialize(string connectionString, string databaseName)
        {
            _mongoService = new MongoService(connectionString, databaseName);
        }

        [OSAction]
        public async Task<bool> ValidateConnectionAsync()
        {
            return await _mongoService.ValidateConnectionAsync();
        }

        [OSAction]
        public async Task<string> GetCollectionDocumentsAsync(string collectionName, int skip, int limit)
        {
            if (!_mongoService.CollectionExists(collectionName))
            {
                throw new ApplicationException($"The collection '{collectionName}' does not exist in the database.");
            }

            var documentCount = _mongoService.GetDocumentCount(collectionName);
            if (documentCount == 0)
            {
                throw new ApplicationException($"The collection '{collectionName}' is empty.");
            }

            var bsonList = await _mongoService.GetCollectionDocumentsAsync(collectionName, skip, limit);
            var jsonArray = new BsonArray(bsonList);
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.CanonicalExtendedJson };
            var json = jsonArray.ToJson(jsonWriterSettings);

            return json;
        }

        [OSAction(Description = "Performs an aggregation operation on a collection and returns the results in JSON format.")]
        public async Task<string> AggregateCollectionAsync(string collectionName, string aggregatePipeline)
        {
            if (!_mongoService.CollectionExists(collectionName))
            {
                throw new ApplicationException($"The collection '{collectionName}' does not exist in the database.");
            }

            var bsonPipeline = BsonSerializer.Deserialize<BsonDocument[]>(aggregatePipeline);
            var aggregateResult = await _mongoService.AggregateCollectionAsync(collectionName, bsonPipeline);
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.CanonicalExtendedJson };
            var jsonResult = aggregateResult.ToJson(jsonWriterSettings);

            return jsonResult;
        }

        [OSAction(Description = "Creates a document in the specified collection.")]
        public async Task CreateDocumentAsync(string collectionName, string documentJson)
        {
            await _mongoService.CreateDocumentAsync(collectionName, documentJson);
        }

        [OSAction(Description = "Retrieves documents from the specified collection as JSON.")]
        public async Task<string> GetDocumentsAsync(string collectionName, string filterJson)
        {
            var bsonDocuments = await _mongoService.GetDocumentsAsync(collectionName, filterJson);
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.CanonicalExtendedJson };
            return bsonDocuments.ToJson(jsonWriterSettings);
        }

        [OSAction(Description = "Update documents from the specified collection.")]
        public async Task UpdateDocumentAsync(string collectionName, string filterJson, string updateJson)
        {
            await _mongoService.UpdateDocumentAsync(collectionName, filterJson, updateJson);
        }

        [OSAction(Description = "Delete documents from the specified collection.")]
        public async Task DeleteDocumentAsync(string collectionName, string filterJson)
        {
            await _mongoService.DeleteDocumentAsync(collectionName, filterJson);
        }
    }
}