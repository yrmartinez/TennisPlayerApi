using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TennisPlayerApiAwsLambda.Services.Interfaces;

namespace TennisPlayerApiAwsLambda.Models
{
    public class Tournament : MongoDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Matches")]
        public virtual List<Match> Matches { get; set; }
        [BsonElement("SeasonId")]
        public string SeasonId { get; set; }
        [BsonElement("Season")]
        public virtual Season Season { get; set; }
    }
}