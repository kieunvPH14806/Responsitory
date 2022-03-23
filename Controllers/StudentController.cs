using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo_Responsitory.Sevices.Interface;
using Demo_Responsitory.ViewsModels.ModelsCreate;
using Demo_Responsitory.ViewsModels.ModelsShow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Responsitory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService?? throw new ArgumentNullException(nameof(studentService));
        }

        [HttpGet]
        public IEnumerable<StudentShow> GetAll()
        {
            return _studentService.GetCollection();
        }

        [HttpGet("{name}")]
        public IEnumerable<StudentShow> GetOne(string name)
        {
            return _studentService.GetbyStudentNameAsync(name);
        }
        [HttpPost]
        public async Task Create(StudentCreate studentCreate)
        {
            await _studentService.CreateAsync(studentCreate);
        }

        [HttpPut("{id}")]
        public async Task Edit(StudentCreate studentEdit)
        {
            await _studentService.UpdateAsync(studentEdit);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _studentService.DeleteAsync(id);
        }
    }
}
