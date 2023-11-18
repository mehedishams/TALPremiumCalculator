using DataModel.RatingEntities;
using System.Collections.Generic;

namespace TALAPITest.Persistence.InMemoryContext
{
    public static class Ratings
    {
        public static IList<Rating> GetAll()
        {
            return new List<Rating>()
            {
                new Rating()
                {
                    RatingId = 1,
                    RatingName = "Professional",
                    Factor = 1.00M
                },
                new Rating()
                {
                    RatingId = 2,
                    RatingName = "White Collar",
                    Factor = 1.25M
                },
                new Rating()
                {
                    RatingId = 3,
                    RatingName = "Light Manual",
                    Factor = 1.50M
                },
                new Rating()
                {
                    RatingId = 4,
                    RatingName = "Heavy Manual",
                    Factor = 1.75M
                }
            };
        }
    }
}
