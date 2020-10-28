using System;
using System.Collections.Generic;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseDataController : ControllerBase
    {

        readonly INurseBusinessLogic _nurseBusinessLogic;
        
        public NurseDataController(INurseBusinessLogic operation)
        {
            _nurseBusinessLogic = operation;
        }
        
        [HttpGet]
        public IEnumerable<NurseDataModel> Get()
        {
            try
            {
                return _nurseBusinessLogic.GetNurse();
            }
            catch
            {
                return null;
            }
           
        }

        
        [HttpPost("validate")]

        public string validate([FromBody] NurseDataModel nurse)
        {


            var response = "Validation Failed";
            Console.WriteLine(nurse.NurseName);
            Console.WriteLine(nurse.WardId);

            if (nurse.NurseName == "Admin")
                return "Admin Login";
            else
            {
                response = matchName(nurse.NurseName, nurse.WardId);
            }

            return response;
        }

        public string matchName(string name, string id)
        {
            List<NurseDataModel> nurseList = (List<NurseDataModel>)_nurseBusinessLogic.GetNurse();
            var reply = "Validation Failed";

            for (int i = 0; i < nurseList.Count; i++)
            {
                if (name == nurseList[i].NurseName)
                {
                    reply = matchId(nurseList[i].WardId, id);
                }
            }

            return reply;

        }

        public string matchId(string id, string id2)
        {
            var reply = "Validation Failed";
            if (id == id2)
                reply = "Validation Succesfull";

            return reply;
        }


        [HttpPost("AddNurse")]
        public ActionResult <IEnumerable<dynamic>> Post([FromBody] NurseDataModel nurse)
        {
            _nurseBusinessLogic.InsertNurse(nurse);
            return StatusCode(200);
        }

        

    }
}
