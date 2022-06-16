using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.User
{
    [Area("User")]
    [Route("[area]/api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
    }
}
