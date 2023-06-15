using EmpAPI1.Model;
using EmpAPI1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;
namespace EmpAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpRepository _empRepository;

        public EmployeesController(IEmpRepository empRepository)

        {

            _empRepository = empRepository;

        }

        //HttpGet signifies that this method will handle all Get 

        //Http Request

        [HttpGet]

        public async Task<IEnumerable<Employee>> GetEmployees()

        {

            return await _empRepository.Get();

        }

        [HttpGet("{EmpId}")]

        public async Task<ActionResult<Employee>> GetEmployees(int EmpId)

        {

            return await _empRepository.Get(EmpId);

        }

        //HttpPost signifies that this method will handle all Post 

        //Http Request

        [HttpPost]

        public async Task<ActionResult<Employee>> PostEmployees([FromForm] Employee employee)

        {

            var newEmployee = await _empRepository.Create(employee);

            return CreatedAtAction(nameof(GetEmployees), new { EmpId = newEmployee.EmpId }, newEmployee);

        }

        //HttpPut signifies that this method will handle all Put 

        //Http Request

        [HttpPut]

        public async Task<ActionResult> PutEmployees(int EmpId, [FromBody] Employee employee)

        {

            //Check if the given id is present database or not

            // if not then we will return bad request

            if (EmpId != employee.EmpId)

            {

                return BadRequest();

            }

            await _empRepository.Update(employee);

            return NoContent();

        }

        //HttpDelete signifies that this method will handle all 

        //Http Delete Request

        [HttpDelete("{EmpId}")]

        public async Task<ActionResult> Delete(int EmpId)

        {

            var employeeToDelete = await _empRepository.Get(EmpId);

            // first we will check i the given id is 

            //present in database or not

            if (employeeToDelete == null)

                return NotFound();

            await _empRepository.Delete(employeeToDelete.EmpId);

            return NoContent();

        }
    }
}
