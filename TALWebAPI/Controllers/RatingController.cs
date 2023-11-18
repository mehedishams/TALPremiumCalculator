using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TALWebAPI.App.Rating.Queries;

namespace TALWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : BaseController
    {
        [HttpGet]
        public string GetRating()
        {
            return "Ok";
        }

        [HttpPost]
        public async Task<RatingQueryResult> GetRating([FromBody] RatingQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
