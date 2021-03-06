﻿using System.Collections.Generic;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public ActionResult InsertIcuWardInfo([FromBody] IcuWardLayoutModel objLayoutModel)
        {
            try
            {
                _icuLayoutManagement.AddLayoutInformation(objLayoutModel);
                return Ok(200);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getBedsInformation/{wardid}")]
        public IEnumerable<BedInformation> GetIcuWardInfo(string wardid){
            try
            {
                return _icuLayoutManagement.GetBedInformation(wardid);
            }
            catch
            {
                return null;
            }
        }
        

        [HttpGet("wardDetail")]

        public IEnumerable<IcuWardInformation> Get()
        {
            try
            {
                return _icuLayoutManagement.Getall();
            }
            catch
            {
                return null;
            }
            
        }

        

    }
}
