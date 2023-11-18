using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TALWebAPI.App.Occupation.Query;

namespace TALWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OccupationController : BaseController
    {
        [HttpGet]
        public async Task<IList<OccupationQueryResult>> GetOccupation()
        {
            return await Mediator.Send(new OccupationQuery());
        }
    }
}
