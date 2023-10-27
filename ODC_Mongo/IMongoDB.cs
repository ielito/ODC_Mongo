using OutSystems.ExternalLibraries.SDK;
using System.Collections.Generic;

namespace MongoDB_ODC
{
    [OSInterface(Name = "MongoDB")]
    public interface IMongoDB
    {
        bool ValidateConnection(string connectionString, string databaseName);
        string GetCollectionDocuments(string collectionName, string connectionString, string databaseName, int skip, int limit);
    }
}