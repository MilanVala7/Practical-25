using Practical25.DAL.Repositories;

namespace Practical25.API.Handlers.GetEmployeeById;

public class GetEmployeeByIdHandler(EmployeeQueryRepo employeeQueryRepo)
    : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeResponse>
{
    public async Task<GetEmployeeResponse> Handle(GetEmployeeByIdRequest req, CancellationToken cancellationToken)
    {
        var employee = await employeeQueryRepo.GetByIdAsync(req.Id, cancellationToken);

        if (employee is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        return new GetEmployeeResponse(
            employee.Id,
            employee.Name,
            employee.Salary,
            employee.DepartmentId,
            employee.EmailId,
            employee.JoiningDate,
            employee.Status,
            employee.Notes);
    }
}
