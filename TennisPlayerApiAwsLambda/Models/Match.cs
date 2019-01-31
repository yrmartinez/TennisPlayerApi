using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TennisPlayerApiAwsLambda.Models
{
    public class Match
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("Surface")]
        public Surface Surface { get; set; }
        [BsonElement("TournamentId")]
        public int TournamentId { get; set; }
        [BsonElement("WinnerPlayerId")]
        public int WinnerPlayerId { get; set; }
        [BsonElement("LooserPlayerId")]
        public int LooserPlayerId { get; set; }
        [BsonElement("Score")]
        public string Score { get; set; }
        [BsonElement("Tournament")]
        public virtual Tournament Tournament { get; set; }
        [BsonElement("WinnerPlayer")]
        public virtual Player WinnerPlayer { get; set; }
        [BsonElement("LooserPlayer")]
        public virtual Player LooserPlayer { get; set; }
    }
}
