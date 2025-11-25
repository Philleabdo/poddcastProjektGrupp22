using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PoddApp.Models
{
    public class Poddflode
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Namn { get; set; }
        public string RssUrl { get; set; }
        public string Kategori { get; set; }
        public DateTime SkapaDatum { get; set; }
    }
}
