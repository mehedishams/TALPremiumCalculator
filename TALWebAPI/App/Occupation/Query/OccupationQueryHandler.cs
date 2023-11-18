using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TALWebAPI.Persistence.Interfaces;

namespace TALWebAPI.App.Occupation.Query
{
    public class OccupationQueryHandler : IRequestHandler<OccupationQuery, IList<OccupationQueryResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OccupationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<OccupationQueryResult>> Handle(OccupationQuery request, CancellationToken cancellationToken)
        {
            var occupations = await _unitOfWork.OccupationRepo.GetOccupations();
            return occupations;
        }
    }
}
