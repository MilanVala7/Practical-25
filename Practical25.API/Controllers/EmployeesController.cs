using Microsoft.AspNetCore.Mvc;
using Practical25.API.Handlers.CreateEmployee;
using Practical25.API.Handlers.DeleteEmployee;
using Practical25.API.Handlers.GetAllEmployees;
using Practical25.API.Handlers.GetEmployeeById;
using Practical25.API.Handlers.UpdateEmployee;

namespace Practical25.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController(IMediator med) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateEmployeeResponse>> Create(CreateEmployeeRequest req, CancellationToken cancellationToken)
    {
        var response = await med.Send(req, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UpdateEmployeeResponse>> Update(int id, UpdateEmployeeRequest req,
        CancellationToken cancellationToken)
    {
        if (id != req.Id)
        {
            return BadRequest("Route-id and request-id must match.");
        }

        try
        {
            var res = await med.Send(req, cancellationToken);
            return Ok(res);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DeleteEmployeeResponse>> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            var res = await med.Send(new DeleteEmployeeRequest(id), cancellationToken);
            return Ok(res);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetEmployeeResponse>> GetById([FromQuery]  int? id, CancellationToken cancellationToken)
    {
        try
        {
            if(id == null)
            {
                var employees = await med.Send(new GetAllEmployeesRequest(), cancellationToken);
                return Ok(employees);
            }

            var emp = await med.Send(new GetEmployeeByIdRequest(id), cancellationToken);
            return Ok(emp);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
