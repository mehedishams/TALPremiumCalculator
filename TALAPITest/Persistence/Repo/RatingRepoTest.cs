using DataModel.Context;
using NUnit.Framework;
using System.Threading.Tasks;
using TALAPITest.Persistence.InMemoryContext;
using TALWebAPI.App.Rating.Queries;
using TALWebAPI.Persistence.Repositories;

namespace TALAPITest.Persistence.Repo
{
    [TestFixture]
    public class RatingRepoTest
    {
        private readonly TALDBContext _talDbContext;

        public RatingRepoTest()
        {
            _talDbContext = TALDBContextFactory.Create();
        }

        [TestCase]
        public async Task GetRating_ProvideCleanerOccupationId_GetRelevantFactor()
        {
            // Arrange
            var ratingRepo = new RatingRepository(_talDbContext);
            var ratingQuery = new RatingQuery()
            {
                OccupationId = 1
            };

            // Act
            var result = await ratingRepo.GetRating(ratingQuery);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Factor, 1.50M);
        }

        [TestCase]
        public async Task GetRating_ProvideDoctorOccupationId_GetRelevantFactor()
        {
            // Arrange
            var ratingRepo = new RatingRepository(_talDbContext);
            var ratingQuery = new RatingQuery()
            {
                OccupationId = 2
            };

            // Act
            var result = await ratingRepo.GetRating(ratingQuery);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Factor, 1.00M);
        }

        [TestCase]
        public async Task GetRating_ProvideAuthorOccupationId_GetRelevantFactor()
        {
            // Arrange
            var ratingRepo = new RatingRepository(_talDbContext);
            var ratingQuery = new RatingQuery()
            {
                OccupationId = 3
            };

            // Act
            var result = await ratingRepo.GetRating(ratingQuery);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Factor, 1.25M);
        }

        [TestCase]
        public async Task GetRating_ProvideFarmerOccupationId_GetRelevantFactor()
        {
            // Arrange
            var ratingRepo = new RatingRepository(_talDbContext);
            var ratingQuery = new RatingQuery()
            {
                OccupationId = 4
            };

            // Act
            var result = await ratingRepo.GetRating(ratingQuery);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Factor, 1.75M);
        }

        [TestCase]
        public async Task GetRating_ProvideMechanicOccupationId_GetRelevantFactor()
        {
            // Arrange
            var ratingRepo = new RatingRepository(_talDbContext);
            var ratingQuery = new RatingQuery()
            {
                OccupationId = 5
            };

            // Act
            var result = await ratingRepo.GetRating(ratingQuery);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Factor, 1.75M);
        }

        [TestCase]
        public async Task GetRating_ProvideFloristOccupationId_GetRelevantFactor()
        {
            // Arrange
            var ratingRepo = new RatingRepository(_talDbContext);
            var ratingQuery = new RatingQuery()
            {
                OccupationId = 6
            };

            // Act
            var result = await ratingRepo.GetRating(ratingQuery);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Factor, 1.50M);
        }
    }
}
