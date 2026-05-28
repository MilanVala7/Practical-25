namespace Practical25.API.Handlers.CreateEmployee;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
{
    private readonly EmployeeCommandRepo _empRepo;

    public CreateEmployeeHandler(EmployeeCommandRepo empCommandRepo)
    {
        _empRepo = empCommandRepo;
    }

    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest req, CancellationToken cancellationToken)
    {
        var emp = new Employee
        {
            Name = req.Name,
            Salary = req.Salary,
            DepartmentId = req.DepartmentId,
            EmailId = req.EmailId,
            JoiningDate = DateTime.UtcNow,
            Status = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var created = await _empRepo.CreateAsync(emp, cancellationToken);

        return new CreateEmployeeResponse(
            created.Id,
            created.Name,
            created.Salary,
            created.DepartmentId,
            created.EmailId,
            created.JoiningDate,
            created.Status);
    }
}
