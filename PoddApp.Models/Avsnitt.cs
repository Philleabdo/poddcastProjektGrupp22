using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PoddApp.Models
{
    public class Avsnitt
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string PoddflodeId { get; set; }
        
        public string Titel{ get; set; }
        public string Lank { get; set; }
        public string Beskrivning { get; set; }
        public DateTime PubliceringsDatum { get; set; }

    }
}
