using DataModel.Persistence.InMemoryContext;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TALWebAPI.Persistence.Interfaces;

namespace TALWebAPI.App.Rating.Queries
{
    public class RatingQueryHandler : IRequestHandler<RatingQuery, RatingQueryResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Calculates the rating factor for the given occupation. E.g.: 1.25 for Author.
        /// </summary>
        /// <param name="query"><see cref="RatingQuery"/> object containing the seleted occupation id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The rating factor for the given occupation.</returns>
        public Task<RatingQueryResult> Handle(RatingQuery query, CancellationToken cancellationToken)
        {
            var context = TALContextFactory.Create();
            return _unitOfWork.RatingRepo.GetRating(query);
        }
    }
}
