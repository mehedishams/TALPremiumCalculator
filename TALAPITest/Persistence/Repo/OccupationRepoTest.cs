using DataModel.Context;
using NUnit.Framework;
using System.Threading.Tasks;
using TALAPITest.Persistence.InMemoryContext;
using TALWebAPI.Persistence.Repositories;

namespace TALAPITest.Persistence.Repo
{
    [TestFixture]
    public class OccupationRepoTest
    {
        private readonly TALDBContext _talDbContext;

        public OccupationRepoTest()
        {
            _talDbContext = TALDBContextFactory.Create();
        }

        [Test]
        public async Task GetOccupations_ShouldReturnAllAvailableOccupations()
        {
            // Arrange
            var occupationRepo = new OccupationRepository(_talDbContext);

            // Act
            var result = await occupationRepo.GetOccupations();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 6);
        }
    }
}
