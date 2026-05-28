namespace Practical25.API.Handlers.UpdateEmployee;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
{
    private readonly EmployeeCommandRepo _empRepo;
    public UpdateEmployeeHandler(EmployeeCommandRepo repo)
    {
        _empRepo = repo;
    }
    public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeRequest req, CancellationToken cancellationToken)
    {
        var emp = await _empRepo.GetByIdAsync(req.Id, cancellationToken);

        if (emp is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        emp.Name = req.Name;
        emp.Salary = req.Salary;
        emp.DepartmentId = req.DepartmentId;
        emp.EmailId = req.EmailId;

        var res = await _empRepo.UpdateAsync(emp, cancellationToken);

        return new UpdateEmployeeResponse(
            res.Id,
            res.Name,
            res.Salary,
            res.DepartmentId,
            res.EmailId,
            res.JoiningDate,
            res.Status,
            res.Notes);
    }
}
