using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace Landmark.API.MDB
{


    public class MongoRepository : IMongoRepository
    {
        public MongoRepository()
        {
            this.Init();
        }
        /// <summary>
        /// The connection string name.
        /// </summary>
        private const string CONNECTIONSTRING = "mdb:applicationdb";

        /// <summary>
        /// The tablename.
        /// </summary>
        private const string TABLENAME = "user_locations";

        /// <summary>
        /// The json serializer settings.
        /// </summary>
        private JsonSerializerSettings jsonSerializerSettings;

        /// <summary>
        /// The application collection.
        /// </summary>
        private IMongoCollection<UserLocationModel> userLocationCollection;

        /// <summary>
        /// The _client.
        /// </summary>
        private IMongoClient client;

        /// <summary>
        /// The _database.
        /// </summary>
        private IMongoDatabase database;

        public async Task<List<UserLocationModel>> GetUserLocations(string username)
        {
            var filter = Builders<UserLocationModel>.Filter.Eq("username", username);
            return await this.userLocationCollection.Find(filter).ToListAsync();
        }

        public async Task<List<UserLocationModel>> GetUserLocations()
        {
            var filter = Builders<UserLocationModel>.Filter.Empty;
            return await this.userLocationCollection.Find(filter).ToListAsync();
        }
        public async Task<UserLocationModel> AddUser(UserLocationModel user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                user.Id = ObjectId.GenerateNewId().ToString();
            }

            await this.userLocationCollection.InsertOneAsync(user);
            return user;
        }


        public void Init()
        {
            var defaultDatabase = "tigerspike";
            this.jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("CamelCase", pack, t => true);

            this.client = new MongoClient(ConfigurationManager.AppSettings["mdb:connection"]);

            this.database = this.client.GetDatabase(defaultDatabase);
            this.userLocationCollection = this.database.GetCollection<UserLocationModel>(TABLENAME);
        }
    }


}