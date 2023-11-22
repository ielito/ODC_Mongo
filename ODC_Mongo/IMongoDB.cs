using OutSystems.ExternalLibraries.SDK;
using System.Collections.Generic;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_ODC
{
    [OSInterface(Description = "Interface for MongoDB operations", IconResourceName = "ODC_Mongo.resources.mongodb.ico")]
    //[OSInterface(Description = "MongoDB Connection", Name = "MongoDB")]
    public interface IMongoDB
    {
        // Config Actions
        bool ValidateConnection(string connectionString, string databaseName);
        string GetCollectionDocuments(string collectionName, string connectionString, string databaseName, int skip, int limit);
        string AggregateCollection(string collectionName, string connectionString, string databaseName, string aggregatePipeline);
        void Initialize(string connectionString, string databaseName);
        // CRUD Actions
        void CreateDocument(string connectionString, string databaseName, string collectionName, string documentJson);
        string GetDocuments(string connectionString, string databaseName, string collectionName, string filterJson);
        void UpdateDocument(string collectionName, string filterJson, string updateJson, string connectionString, string databaseName);
        void DeleteDocument(string collectionName, string filterJson, string connectionString, string databaseName);
    }
}