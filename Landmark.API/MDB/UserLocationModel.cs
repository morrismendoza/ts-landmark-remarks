using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landmark.API.MDB
{
    public class UserLocationModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("latitude")]
        public decimal Latitude { get; set; }

        [BsonElement("longitude")]
        public decimal Longitude { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }

        [BsonElement("date_created")]
        public DateTime DateCreated { get; set; }

        [BsonElement("full_address")]
        public string Address { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }
    }
}