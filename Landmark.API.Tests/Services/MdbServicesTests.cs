
using Landmark.API.MDB;
using Landmark.API.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Landmark.API.Tests.Services
{
    /// <summary>
    /// Mock Tests for User services
    /// </summary>
    [TestFixture]
    public class MdbServicesTests
    {
        private Mock<IMongoRepository> mockMongo;

        [SetUp]
        public void Setup()
        {
            this.mockMongo = new Mock<IMongoRepository>();
        }

        [Test]
        public async void AddUserLocationsTests()
        {
            var mockResult = new UserLocationModel { Id = "1", Username = "testuser" };
            var svc = new MongoUserService(this.mockMongo.Object);

            this.mockMongo.Setup(x => x.AddUser(It.IsAny<UserLocationModel>())).Returns(Task.FromResult(mockResult));

            var addedUser = await svc.AddUserLocationAsync(new UserLocationModel());

            this.mockMongo.Verify(x => x.AddUser(It.IsAny<UserLocationModel>()));

            Assert.IsNotNull(addedUser);
            Assert.IsTrue(addedUser.Id == mockResult.Id);
            Assert.IsTrue(addedUser.Username == mockResult.Username);
        }

        [Test]
        public async void GetUserLocationsTests()
        {
            var mockResult = new List<UserLocationModel>
            {
                new UserLocationModel{ Id = "1", Username = "testuser" },
                new UserLocationModel { Id = "2", Username = "testuser 2" }
            };

            var svc = new MongoUserService(this.mockMongo.Object);

            this.mockMongo.Setup(x => x.GetUserLocations(It.IsAny<string>())).Returns(Task.FromResult(mockResult));
            this.mockMongo.Setup(x => x.GetUserLocations()).Returns(Task.FromResult(mockResult));

            var users = await svc.GetUserLocationAsync(string.Empty);

            this.mockMongo.Verify(x => x.GetUserLocations());

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count > 0);
        }

    }
}
