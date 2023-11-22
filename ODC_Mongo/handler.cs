using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDBHandler
{
    private IMongoDatabase database;

    public MongoDBHandler(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        this.database = client.GetDatabase(databaseName);
    }

    public void CreateDocument(string collectionName, string documentJson)
    {
        Console.WriteLine($"Creating document in collection: {collectionName}");
        Console.WriteLine($"Document JSON: {documentJson}");

        var collection = database.GetCollection<BsonDocument>(collectionName);
        var document = BsonDocument.Parse(documentJson);
        collection.InsertOne(document);

        Console.WriteLine("Document created successfully.");
    }

    public List<BsonDocument> GetDocuments(string collectionName, string filterJson)
    {
        var collection = database.GetCollection<BsonDocument>(collectionName);
        var filter = BsonDocument.Parse(filterJson);
        return collection.Find(filter).ToList();
    }

    public void UpdateDocument(string collectionName, string filterJson, string updateJson)
    {
        var collection = database.GetCollection<BsonDocument>(collectionName);
        var filter = BsonDocument.Parse(filterJson);
        var update = BsonDocument.Parse(updateJson);
        collection.UpdateOne(filter, update);
    }

    public void DeleteDocument(string collectionName, string filterJson)
    {
        var collection = database.GetCollection<BsonDocument>(collectionName);
        var filter = BsonDocument.Parse(filterJson);
        collection.DeleteOne(filter);
    }
}
