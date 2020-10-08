using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IcuLayoutController : Controller
    {
        private readonly Repository.IIcuLayoutManagement _icuLayoutManagement;

        public IcuLayoutController(Repository.IIcuLayoutManagement icuLayout)
        {
            _icuLayoutManagement = icuLayout;
        }

        [HttpPost("IcuWardInfo")]
        public IActionResult InsertIcuWardInfo([FromBody] IcuWardLayoutModel objLayoutModel)
        {
            bool isWardInfoStored = _icuLayoutManagement.GetLayoutInformation(objLayoutModel);
            if (isWardInfoStored)
                return Ok(200);
            return StatusCode(500);
        }
    }
}
