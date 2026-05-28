namespace Practical25.API.Handlers.DeleteEmployee;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, DeleteEmployeeResponse>
{
    private readonly EmployeeCommandRepo _empRepo;

    public DeleteEmployeeHandler(EmployeeCommandRepo empCommandRepo)
    {
        _empRepo = empCommandRepo;
    }

    public async Task<DeleteEmployeeResponse> Handle(DeleteEmployeeRequest req, CancellationToken cancellationToken)
    {
        var emp = await _empRepo.GetByIdAsync(req.Id, cancellationToken);

        if (emp is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        await _empRepo.DeleteAsync(emp, cancellationToken);

        return new DeleteEmployeeResponse(emp.Id, emp.Status, emp.DeletedAt, emp.UpdatedAt);
    }
}
