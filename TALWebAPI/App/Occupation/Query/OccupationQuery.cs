using MediatR;
using System.Collections.Generic;

namespace TALWebAPI.App.Occupation.Query
{
    public class OccupationQuery : IRequest<IList<OccupationQueryResult>>
    {
    }
}
