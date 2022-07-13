using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWithSQL.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }
    [BsonElement("id")]
    public int id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = null!;

    [BsonElement("Department")]
    public string Department { get; set; }
    [BsonElement("Address")]
    public string Address { get; set; }

    [BsonElement("Salary")]
    public string Salary { get; set; } = null!;

}