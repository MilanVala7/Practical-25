using Practical25.API.Models.Responses;
using Practical25.DAL.Repositories;
using Practical25.Domain.Entities;

namespace Practical25.API.Handlers.CreateEmployee;

public class CreateEmployeeHandler(EmployeeCommandRepo employeeCommandRepo)
    : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
{
    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Name = request.Name,
            Salary = request.Salary,
            DepartmentId = request.DepartmentId,
            EmailId = request.EmailId,
            JoiningDate = DateTime.UtcNow,
            Status = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var created = await employeeCommandRepo.CreateAsync(employee, cancellationToken);

        return new CreateEmployeeResponse(
            created.Id,
            created.Name,
            created.Salary,
            created.DepartmentId,
            created.EmailId,
            created.JoiningDate,
            created.Status,
            created.Notes);
    }
}
