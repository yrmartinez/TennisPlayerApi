using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TennisPlayerApiAwsLambda.Services.Interfaces
{
    public class MongoDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}