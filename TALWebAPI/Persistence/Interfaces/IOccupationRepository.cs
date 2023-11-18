using System.Collections.Generic;
using System.Threading.Tasks;
using TALWebAPI.App.Occupation.Query;

namespace TALWebAPI.Persistence.Interfaces
{
    public interface IOccupationRepository
    {
        Task<IList<OccupationQueryResult>> GetOccupations();
    }
}
