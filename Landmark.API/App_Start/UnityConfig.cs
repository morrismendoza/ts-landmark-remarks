using Landmark.API.MDB;
using Landmark.API.Services;
using Microsoft.Practices.Unity;
using MongoDB.Bson.Serialization;
using System.Web.Http;
using Unity.WebApi;

namespace Landmark.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IUserServices, UserServices>();
            container.RegisterType<IMongoUserService, MongoUserService>();

            container.RegisterType<IMongoRepository, MongoRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}