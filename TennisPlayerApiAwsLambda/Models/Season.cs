using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TennisPlayerApiAwsLambda.Services.Interfaces;

namespace TennisPlayerApiAwsLambda.Models
{
    public class Season : MongoDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Tournaments")]
        public virtual List<Tournament> Tournaments { get; set; }
    }
}