using OutSystems.ExternalLibraries.SDK;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_ODC
{
    [OSInterface(Description = "Interface for MongoDB operations", IconResourceName = "MongoDB_ODC.resources.mongodb.ico")]
    public interface IMongoDB
    {
        void Initialize(string connectionString, string databaseName);
        Task<bool> ValidateConnectionAsync();
        Task<string> GetCollectionDocumentsAsync(string collectionName, int skip, int limit);
        Task<string> AggregateCollectionAsync(string collectionName, string aggregatePipeline);
        Task CreateDocumentAsync(string collectionName, string documentJson);
        Task<string> GetDocumentsAsync(string collectionName, string filterJson);
        Task UpdateDocumentAsync(string collectionName, string filterJson, string updateJson);
        Task DeleteDocumentAsync(string collectionName, string filterJson);
    }
}