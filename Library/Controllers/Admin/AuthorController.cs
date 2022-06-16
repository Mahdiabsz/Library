using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Admin
{
    [Area("Admin")]
    [Route("[area]/api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
    }
}
