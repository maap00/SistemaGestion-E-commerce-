using Microsoft.AspNetCore.Mvc;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : Controller
    {
        // GET: NameController
        [HttpGet]
        public string GetMyName()
        {
            return "Marco Astudillo";
        }

    }
}
