using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return _nurseBusinessLogic.getNurse();
        }

        
        [HttpPost("validate")]

        public string validate([FromBody] NurseDataModel nurse)
        {
            List<NurseDataModel> nurseList = (List<NurseDataModel>)_nurseBusinessLogic.getNurse();
            var response = "Validation Failed";
            Console.WriteLine(nurseList.Count);

            for(int i =0; i < nurseList.Count;i++)
            {
                if (nurse.NurseName == nurseList[i].NurseName)
                {
                    Console.WriteLine(nurse.NurseName);
                    if (nurse.NurseId == nurseList[i].NurseId)
                    {
                        response = "Validation Succesful";
                        return response;
                    }
                        
                }
                
            }

            return response;
        }
      
        [HttpPost("AddNurse")]
        public void Post([FromBody] NurseDataModel nurse)
        {
            _nurseBusinessLogic.InsertNurse(nurse);
        }

        

    }
}
