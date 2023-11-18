using DataModel.Context;
using DataModel.OccupationEntities;
using DataModel.RatingEntities;
using Microsoft.EntityFrameworkCore;
using System;

namespace TALAPITest.Persistence.InMemoryContext
{
    public class TALDBContextFactory
    {
        public static TALDBContext Create()
        {
            var options = new DbContextOptionsBuilder<TALDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new TALDBContext(options);
            context.Database.EnsureCreated();
            context.Set<Occupation>().AddRange(Occupations.GetAll());
            context.Set<Rating>().AddRange(Ratings.GetAll());
            context.SaveChanges();
            return context;
        }
    }
}
