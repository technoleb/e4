using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Common;
using StudentAPI.Model;
using StudentAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class StudentController : Controller
    {
        #region Fields
        private readonly IStudentRepository _iStudentRepository;
        #endregion

        #region Controller
        public StudentController(IStudentRepository iStudentRepository)
        {
            _iStudentRepository = iStudentRepository;
        }
        #endregion

        [HttpGet]
        public APIResponse Get()
        {
            var result = _iStudentRepository.GetStudent();
            return result;
        }

        [HttpGet]
        public APIResponse Find(int Id)
        {
            var result = _iStudentRepository.GetStudent(Id);
            return result;
        }

        [HttpPut]
        public APIResponse Update([FromBody]Student obj)
        {
            var result = _iStudentRepository.SaveStudent(obj);
            return result;
        }

        [HttpPost]
        public APIResponse Add([FromBody] Student obj)
        {
            var result = _iStudentRepository.SaveStudent(obj);
            return result;
        }
        
        [HttpDelete]
        public APIResponse Delete(int Id)
        {
            var result = _iStudentRepository.DeleteStudent(Id);
            return result;
        }

    }
}
