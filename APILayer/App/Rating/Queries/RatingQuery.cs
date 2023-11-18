using MediatR;
namespace TALWebAPI.App.Rating.Queries
{
    public class RatingQuery : IRequest<RatingQueryResult>
    {
        public int OccupationId { get; set; }
    }
}
