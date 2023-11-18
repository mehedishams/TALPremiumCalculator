using DataModel.Context;
using DataModel.OccupationEntities;
using DataModel.RatingEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TALWebAPI.App.Rating.Queries;
using TALWebAPI.Persistence.Interfaces;

namespace TALWebAPI.Persistence.Repositories
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RatingRepository"/> class.
        /// </summary>
        /// <param name="talContext">The STPService context.</param>
        public RatingRepository(TALContext talContext) : base(talContext)
        {
        }

        /// <summary>
        /// Retrieves ratings from a given occupation id.
        /// </summary>
        /// <param name="query"><see cref="RatingQuery"/> class containing the selected occupation id. E.g.: 3 for Author.</param>
        /// <returns>Rating factor for the given occupation. E.g.: 1.25 for Author.</returns>
        public async Task<RatingQueryResult> GetRating(RatingQuery query)
        {
            var factor = await (from o in BaseTalContext.Set<Occupation>().AsNoTracking()
                                join r in BaseTalContext.Set<Rating>().AsNoTracking()
                                    on o.RatingId equals r.RatingId
                                where o.OccupationId == query.OccupationId
                                select r.Factor).FirstOrDefaultAsync();
            return new RatingQueryResult() { Factor = factor };
        }
    }
}
