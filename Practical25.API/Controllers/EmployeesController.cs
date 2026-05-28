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

    [HttpPut]
    public async Task<ActionResult<UpdateEmployeeResponse>> Update(UpdateEmployeeRequest req,
        CancellationToken cancellationToken)
    {
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

    [HttpGet]
    public async Task<ActionResult<GetEmployeeResponse>> GetById(int? id, CancellationToken cancellationToken)
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
