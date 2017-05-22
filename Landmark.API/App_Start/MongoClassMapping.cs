using Landmark.API.MDB;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landmark.API
{
    public static class MongoClassMapping
    {
        public static void InitMapping()
        {
            BsonClassMap.RegisterClassMap<UserLocationModel>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
            });
        }
    }
}