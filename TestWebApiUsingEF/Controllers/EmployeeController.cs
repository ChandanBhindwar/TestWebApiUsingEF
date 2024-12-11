using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApiUsingEF.Models;
using TestWebApiUsingEF.Services;

namespace TestWebApiUsingEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllEmployee()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);
                if (employee == null) return NotFound();
                return Ok(employee);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteEmployeeById(int id)
        {
            try
            {
                var model = _employeeService.DeleteEmployeeById(id);
                return Ok(model);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveEmployee(Employees employee)
        {
            try
            {
                var model = _employeeService.SaveEmployee(employee);
                return Ok(model);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}