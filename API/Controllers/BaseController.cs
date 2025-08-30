using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // all controllers inherit from BaseController
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase{ }
}