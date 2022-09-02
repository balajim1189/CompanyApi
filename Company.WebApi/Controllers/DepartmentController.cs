using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Entities;
using Company.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        public IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var details = await _departmentService.GetDepartmentById(id);
            return Ok(details);
        } 

        [HttpGet("getdepartments")]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            var dept = await _departmentService.GetDepartments();
            return Ok(dept);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Department>> Create(Department department)
        {
            var dep = await _departmentService.Create(department);
            return Ok(dep);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Department>> Update(Department department)
        {
            var result = await _departmentService.Update(department);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Department>> Delete(int id)
        {
            await _departmentService.Delete(id);
            return RedirectToAction("Read");
        }

    }
}