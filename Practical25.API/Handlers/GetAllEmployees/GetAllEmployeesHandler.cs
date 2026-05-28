namespace Practical25.API.Handlers.GetAllEmployees;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesRequest, GetAllEmployeesResponse>
{
    private readonly EmployeeQueryRepo _empRepo;

    public GetAllEmployeesHandler(EmployeeQueryRepo employeeQueryRepo)
    {
        _empRepo = employeeQueryRepo;
    }

    public async Task<GetAllEmployeesResponse> Handle(GetAllEmployeesRequest req, CancellationToken cancellationToken)
    {
        var employees = await _empRepo.GetAllAsync(cancellationToken);
        var res = employees
            .Select(emp => new GetEmployeeResponse(
                emp.Id,
                emp.Name,
                emp.Salary,
                emp.DepartmentId,
                emp.EmailId,
                emp.JoiningDate,
                emp.Status))
            .ToList();

        return new GetAllEmployeesResponse(res);
    }
}
