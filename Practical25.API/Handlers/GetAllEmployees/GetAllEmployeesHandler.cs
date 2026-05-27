using Practical25.API.Models.Responses;
using Practical25.DAL.Repositories;

namespace Practical25.API.Handlers.GetAllEmployees;

public class GetAllEmployeesHandler(EmployeeQueryRepo employeeQueryRepo)
    : IRequestHandler<GetAllEmployeesRequest, GetAllEmployeesResponse>
{
    public async Task<GetAllEmployeesResponse> Handle(GetAllEmployeesRequest request, CancellationToken cancellationToken)
    {
        var employees = await employeeQueryRepo.GetAllAsync(cancellationToken);
        var results = employees
            .Select(employee => new GetEmployeeResponse(
                employee.Id,
                employee.Name,
                employee.Salary,
                employee.DepartmentId,
                employee.EmailId,
                employee.JoiningDate,
                employee.Status,
                employee.Notes))
            .ToList();

        return new GetAllEmployeesResponse(results);
    }
}
