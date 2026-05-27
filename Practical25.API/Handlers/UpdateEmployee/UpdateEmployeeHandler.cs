using Practical25.API.Models.Responses;
using Practical25.DAL.Repositories;

namespace Practical25.API.Handlers.UpdateEmployee;

public class UpdateEmployeeHandler(EmployeeCommandRepo employeeCommandRepo)
    : IRequestHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
{
    public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = await employeeCommandRepo.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        employee.Name = request.Name;
        employee.Salary = request.Salary;
        employee.DepartmentId = request.DepartmentId;
        employee.EmailId = request.EmailId;

        var updated = await employeeCommandRepo.UpdateAsync(employee, cancellationToken);

        return new UpdateEmployeeResponse(
            updated.Id,
            updated.Name,
            updated.Salary,
            updated.DepartmentId,
            updated.EmailId,
            updated.JoiningDate,
            updated.Status,
            updated.Notes);
    }
}
