using HateoasSirenSample.Representations;
using Microsoft.AspNetCore.Mvc;

namespace HateoasSirenSample.Controllers
{
    [Route("")]
    public class RootController : Controller
    {
        [HttpGet]
        public Root Get()
        {
            return new Root();
        }
    }
}
