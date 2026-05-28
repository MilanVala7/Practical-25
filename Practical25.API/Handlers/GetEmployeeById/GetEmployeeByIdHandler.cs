namespace Practical25.API.Handlers.GetEmployeeById;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeResponse>
{
    private readonly EmployeeQueryRepo _empRepo;

    public GetEmployeeByIdHandler(EmployeeQueryRepo employeeQueryRepo)
    {
        _empRepo = employeeQueryRepo;
    }

    public async Task<GetEmployeeResponse> Handle(GetEmployeeByIdRequest req, CancellationToken cancellationToken)
    {
        var emp = await _empRepo.GetByIdAsync(req.Id, cancellationToken);

        if (emp is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        return new GetEmployeeResponse(
            emp.Id,
            emp.Name,
            emp.Salary,
            emp.DepartmentId,
            emp.EmailId,
            emp.JoiningDate,
            emp.Status,
            emp.Notes);
    }
}
