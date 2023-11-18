using DataModel.RatingEntities;
using System.Threading.Tasks;
using TALWebAPI.App.Rating.Queries;

namespace TALWebAPI.Persistence.Interfaces
{
    public interface IRatingRepository : IRepositoryBase<Rating>
    {
        Task<RatingQueryResult> GetRating(RatingQuery query);
    }
}
