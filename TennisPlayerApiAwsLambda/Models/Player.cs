using System;
using MongoDB.Bson.Serialization.Attributes;
using TennisPlayerApiAwsLambda.Services.Interfaces;

namespace TennisPlayerApiAwsLambda.Models
{
    public class Player : MongoDocument
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("BirthDate")]
        public DateTime BirthDate { get; set; }
        [BsonElement("BirthPlace")]
        public string BirthPlace { get; set; }
        [BsonElement("Residence")]
        public string Residence { get; set; }
        [BsonElement("WeightLbs")]
        public int WeightLbs { get; set; }
        [BsonElement("Height")]
        public string Height { get; set; }

    }
}
