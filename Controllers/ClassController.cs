using Demo_Responsitory.Sevices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo_Responsitory.ViewsModels.ModelsShow;
using Demo_Responsitory.ViewsModels.ModelsCreate;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo_Responsitory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

       private readonly IClassService _service;

        public ClassController(IClassService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        [HttpGet]
        public IEnumerable<ClassShow> GetAll()
        {
            return _service.GetCollection();
        }
        [HttpGet("{name}")]
        public async  Task<ClassShow> GetOne(string name)
        {
            
          return await _service.GetbyNameClassAsync(name);
          
        }
        [HttpPost]
        public async Task Create(ClassCreate @class)
        {
           await _service.CreateAsync(@class);
        }
        [HttpPut("{id}")]
        public async Task Edit(ClassCreate @class)
        {
            await _service.UpdateAsync(@class);      
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
