using OutSystems.ExternalLibraries.SDK;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MongoDB_ODC
{
    [OSInterface(Description = "MongoDB Connection", IconResourceName = "ODC_Mongo.resources.mongodb.ico")]
    //[OSInterface(Description = "MongoDB Connection", Name = "MongoDB")]
    public interface IMongoDB
    {
        bool ValidateConnection(string connectionString, string databaseName);
        string GetCollectionDocuments(string collectionName, string connectionString, string databaseName, int skip, int limit);
    }
}