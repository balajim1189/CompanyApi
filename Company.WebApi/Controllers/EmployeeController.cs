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
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("getbyid")]

        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var details= await _employeeService.GetEmployeeById(id);
            return Ok(details);
        }

        [HttpGet("getemployees")]
        public async Task<ActionResult<List<Employee>>> GetEmployees() 
        {
            var det= await _employeeService.GetEmployees();
            return Ok(det);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            var res= await _employeeService.Create(employee);
            return Ok(res);
        }
        [HttpPut("update")]
        public async Task<ActionResult<Employee>> Update(Employee employee)
        {
            var resu=await _employeeService.Update(employee);
            return Ok(resu);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            await _employeeService.Delete(id);
            return RedirectToAction("read");
        }
    }
}