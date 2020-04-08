using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
public class EmailRecord
{
    [BsonId]
    public Guid Id { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}
public class MongoCRUD
{
    private IMongoDatabase db;
    public MongoCRUD(string database)
    {
        var client = new MongoClient();
        db = client.GetDatabase(database);
    }
    public void InsertRecords<T>(string table, T record)
    {
        var collection = db.GetCollection<T>(table);
        collection.InsertOne(record);
    }
}
