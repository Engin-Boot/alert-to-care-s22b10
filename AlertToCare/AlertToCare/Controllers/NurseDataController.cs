using System;
using System.Collections.Generic;
using System.Globalization;
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
            
            var response = "Validation Failed";
            List<NurseDataModel> nurseList = (List<NurseDataModel>)_nurseBusinessLogic.getNurse();
            for (int i = 0; i < nurseList.Count; i++)
            {
                if (compareCredentials(nurse.NurseName,nurseList[i].NurseName, nurse.NurseId, nurseList[i].NurseId))
                {
                    response = "Validation Succesful";
                    return response;
                }
            }
            return response;
        }
        private bool compareCredentials(string string1,string string2,string string3,string string4)
        {
            return (string1.Equals(string2) && string3.Equals(string4));
        }
     
      
        [HttpPost("AddNurse")]
        public void Post([FromBody] NurseDataModel nurse)
        {
            _nurseBusinessLogic.InsertNurse(nurse);
        }

        

    }
}
