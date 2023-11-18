using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TALWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")] //response format
    [Consumes("application/json", "application/xml")] //request format 
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
