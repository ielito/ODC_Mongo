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
        bool ValidateConnection(string connectionString, string databaseName);
        string GetCollectionDocuments(string collectionName, string connectionString, string databaseName, int skip, int limit);
        string AggregateCollection(string collectionName, string connectionString, string databaseName, string aggregatePipeline);
    }
}