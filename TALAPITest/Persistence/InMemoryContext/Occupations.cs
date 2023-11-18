using DataModel.OccupationEntities;
using System.Collections.Generic;

namespace TALAPITest.Persistence.InMemoryContext
{
    public static class Occupations
    {
        public static IList<Occupation> GetAll()
        {
            return new List<Occupation>()
            {
                new Occupation()
                {
                    OccupationId = 1,
                    OccupationName = "Cleaner",
                    RatingId = 3
                },
                new Occupation()
                {
                    OccupationId = 2,
                    OccupationName = "Doctor",
                    RatingId = 1
                },
                new Occupation()
                {
                    OccupationId = 3,
                    OccupationName = "Author",
                    RatingId = 2
                },
                new Occupation()
                {
                    OccupationId = 4,
                    OccupationName = "Farmer",
                    RatingId = 4
                },
                new Occupation()
                {
                    OccupationId = 5,
                    OccupationName = "Mechanic",
                    RatingId = 4
                },
                new Occupation()
                {
                    OccupationId = 6,
                    OccupationName = "Florist",
                    RatingId = 3
                }
            };
        }
    }
}
