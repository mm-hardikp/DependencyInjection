using DependencyInjection.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifetimeController : Controller
    {
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;
        private readonly ITransientService _transientService;

        public LifetimeController(
            IScopedService scopedService,
            ISingletonService singletonService,
            ITransientService transientService)
        {
            _scopedService = scopedService;
            _singletonService = singletonService;
            _transientService = transientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Scoped = _scopedService.GetOperationId(),
                Singleton = _singletonService.GetOperationId(),
                Transient = _transientService.GetOperationId()
            });
        }
    }
}
