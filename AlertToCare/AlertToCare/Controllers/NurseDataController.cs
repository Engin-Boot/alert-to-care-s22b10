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
            return _nurseBusinessLogic.GetNurse();
        }

        
        [HttpPost("validate")]

        public string Validate([FromBody] NurseDataModel nurse)
        {


            var response = "Validation Failed";
            Console.WriteLine(nurse.NurseName);
            Console.WriteLine(nurse.WardId);

            if (nurse.NurseName == "Admin")
                return "Admin Login";
            else
            {
                response = MatchName(nurse.NurseName, nurse.WardId);
            }

            return response;
        }

        private string MatchName(string name, string id)
        {
            List<NurseDataModel> nurseList = (List<NurseDataModel>)_nurseBusinessLogic.GetNurse();
            var reply = "Validation Failed";

            for (int i = 0; i < nurseList.Count; i++)
            {
                if (name == nurseList[i].NurseName)
                {
                    reply = MatchId(nurseList[i].WardId, id);
                }
            }

            return reply;

        }

        private string MatchId(string id, string id2)
        {
            var reply = "Validation Failed";
            if (id == id2)
                reply = "Validation Succesfull";

            return reply;
        }


        [HttpPost("AddNurse")]
        public void Post([FromBody] NurseDataModel nurse)
        {
            _nurseBusinessLogic.InsertNurse(nurse);
        }

        

    }
}
