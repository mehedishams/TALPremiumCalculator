using DataModel.Context;
using DataModel.OccupationEntities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALWebAPI.App.Occupation.Query;
using TALWebAPI.Persistence.Interfaces;

namespace TALWebAPI.Persistence.Repositories
{
    public class OccupationRepository : RepositoryBase<Occupation>, IOccupationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OccupationRepository"/> class.
        /// </summary>
        /// <param name="talContext">The STPService context.</param>
        public OccupationRepository(TALDBContext talContext) : base(talContext)
        {
        }

        /// <summary>
        /// Retrieves all the listed occupations from database.
        /// </summary>
        /// <returns>All the listed occupations from database.</returns>
        public async Task<IList<OccupationQueryResult>> GetOccupations()
        {
            var occupations = await BaseTalContext.Set<Occupation>().AsNoTracking()
                .OrderBy(x => x.OccupationId)
                .ToListAsync();

            return occupations.Select(x => new OccupationQueryResult()
            {
                OccupationId = x.OccupationId,
                OccupationName = x.OccupationName
            }).ToList();
        }
    }
}
