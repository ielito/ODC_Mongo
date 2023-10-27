using MongoDB.Bson;
using MongoDB.Driver;
using OutSystems.ExternalLibraries.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using MongoDB.Bson.IO;

namespace MongoDB_ODC
{
    public class MyLibrary : IMongoDB
    {
        public MyLibrary()
        {
            // Construtor público sem parâmetros
        }

        public MyLibrary(int value)
        {
            // Construtor com um parâmetro, se necessário
        }

        [OSAction]
        public bool ValidateConnection(string connectionString, string databaseName)
        {
            var mongoService = new MongoService(connectionString, databaseName);
            return mongoService.ValidateConnection();
        }

        [OSAction]
        public string GetCollectionDocuments(string collectionName, string connectionString, string databaseName, int skip, int limit)
        {
            var mongoService = new MongoService(connectionString, databaseName);

            if (!mongoService.CollectionExists(collectionName))
            {
                throw new ApplicationException($"A coleção '{collectionName}' não existe no banco de dados '{databaseName}'.");
            }

            var documentCount = mongoService.GetDocumentCount(collectionName);
            if (documentCount == 0)
            {
                throw new ApplicationException($"A coleção '{collectionName}' está vazia.");
            }

            var collection = mongoService.GetCollection(collectionName);
            var bsonList = collection.Find(new BsonDocument()).Skip(skip).Limit(limit).ToList();

            var jsonArray = new BsonArray(bsonList);
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var json = jsonArray.ToJson(jsonWriterSettings);

            return json;
        }
    }
}