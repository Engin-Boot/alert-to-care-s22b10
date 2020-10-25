using System.Collections.Generic;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace AlertToCare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IcuLayoutController : Controller
    {
        private readonly IIcuLayoutBusinessLogic _icuLayoutManagement;

        public IcuLayoutController(IIcuLayoutBusinessLogic icuLayout)
        {
            _icuLayoutManagement = icuLayout;
        }

        [HttpPost("IcuWardInfo")]
        public IActionResult InsertIcuWardInfo([FromBody] IcuWardLayoutModel objLayoutModel)
        {
            try
            {
                _icuLayoutManagement.AddLayoutInformation(objLayoutModel);
                return Ok(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getBedsInformation/{wardid}")]
        public IEnumerable<BedInformation> getIcuWardInfo(string wardid){
            return _icuLayoutManagement.getBedInformation(wardid);
        }
        

        [HttpGet("wardDetail")]

        public IEnumerable<IcuWardInformation> GET()
        {
            return _icuLayoutManagement.getall();
        }

        

    }
}
