using Practical25.API.Models.Responses;
using Practical25.DAL.Repositories;

namespace Practical25.API.Handlers.DeleteEmployee;

public class DeleteEmployeeHandler(EmployeeCommandRepo employeeCommandRepo)
    : IRequestHandler<DeleteEmployeeRequest, DeleteEmployeeResponse>
{
    public async Task<DeleteEmployeeResponse> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = await employeeCommandRepo.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        await employeeCommandRepo.DeleteAsync(employee, cancellationToken);

        return new DeleteEmployeeResponse(employee.Id, employee.Status, employee.DeletedAt, employee.UpdatedAt);
    }
}
