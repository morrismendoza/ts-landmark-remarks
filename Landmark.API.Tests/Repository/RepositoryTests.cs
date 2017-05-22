using Landmark.API.MDB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landmark.API.Tests.Repository
{
    [TestFixture]
    public class RepositoryTests
    {
        private IMongoRepository repo;

        [SetUp]
        public void SetUp()
        {
            this.repo = new MongoRepository();
        }

        [Test]
        [Ignore("WARNING:Integration Tests.")]
        public async void AddUserLocationTests()
        {
            var userLocation = new UserLocationModel
            {
                Address = "Sample Address",
                Latitude = new Random().Next(15, 16),
                Longitude = new Random().Next(115, 116),
                DateCreated = DateTime.Now,
                Notes = "Notes Sample",
                Username = "test_user"
            };

            var result = await this.repo.AddUser(userLocation);

            Assert.IsNotNull(result);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
        }

        [Test]
        [Ignore("WARNING:Integration Tests.")]
        public async void GetUserLocationTest()
        {
            var result = await this.repo.GetUserLocations();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
