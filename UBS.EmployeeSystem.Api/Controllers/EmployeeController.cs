using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UBS.EmployeeSystem.Persistence;
using UBS.EmployeeSystem.Abstractions;

namespace UBS.EmployeeSystem.Api.Controllers
{
    public class EmployeeController:ControllerBase
    {
        
        public EmployeeController(EmployeeService employeeService)
        {
            EmployeeService = employeeService ?? throw new ArgumentNullException(nameof(EmployeeService));
        }
        public EmployeeService EmployeeService { get; }

        [Route("Index/Employees")]
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employee = EmployeeService.GetEmployees();
                return Ok(employee);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        //[Route("Index/Admins")]
        //[HttpGet]
        //public IActionResult GetAllAdmmins()
        //{
        //    try
        //    {
        //        var admins = EmployeeService.GetAdmins();
        //        return Ok(admins);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
            
        //}

        [Route("Index/MakeAdmin")]
        [HttpPost]
        public IActionResult CreateAdmin([FromBody] Admin admin)
        {
            try
            {
                var adminEmp = EmployeeService.AddAdmin(admin);
                return Ok(admin);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("Index/{_id}")]
        [HttpGet]
        public IActionResult GetEmpBYId([FromRoute] double _id)
        {
            var emp = EmployeeService.GetSingleEmp(_id);
            return Ok(emp);
        }

        [Route("Index/AddEmployee")]
        [HttpPost]
        public ActionResult CreateEmployee([FromBody] Employee emp)
        {
            try
            {
                var employee = EmployeeService.AddEmployee(emp);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Index/EditEmployee")]
        [HttpPut]
        public IActionResult EditEmployee([FromBody] Employee emp)
        {
            var employee = EmployeeService.GetSingleEmp(emp._id);
            if(employee==null)
            {
                return NotFound();
            }
            EmployeeService.EditEmp(emp);
            return Ok();
        }

        [Route("Index/Delete/{_id}")]
        [HttpDelete]
        public IActionResult DeleteEmployee( double _id)
        {
            var emp = EmployeeService.RemoveEmp(_id);
            return Ok(emp);
        }

        [Route("Index/EmployeeByDepartment/{dname}")]
        [HttpGet]
        public IActionResult GetEmployeeByDept([FromRoute]string dname)
        {
            var emp = EmployeeService.GetEmpDept(dname);
            return Ok(emp);
        }
    }
}
