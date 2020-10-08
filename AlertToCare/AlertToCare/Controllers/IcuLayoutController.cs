using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IcuLayoutController : Controller
    {
        private Repository.IIcuLayoutManagement _icuLayoutManagement;

        public IcuLayoutController(Repository.IIcuLayoutManagement icuLayout)
        {
            this._icuLayoutManagement = icuLayout;
        }

        [HttpPost("IcuWardInfo")]
        public IActionResult InsertIcuWardInfo([FromBody] IcuWardLayoutModel objLayoutModel)
        {
            bool isWardInfoStored = _icuLayoutManagement.GetLayoutInformation(objLayoutModel);
            if (isWardInfoStored == true)
                return Ok(200);
            else
            {
                return StatusCode(500);
            }
        }
    }
}
