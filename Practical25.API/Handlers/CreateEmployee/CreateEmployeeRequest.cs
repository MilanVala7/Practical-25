namespace Practical25.API.Handlers.CreateEmployee;

public record CreateEmployeeRequest(
    string Name,
    decimal Salary,
    Department DepartmentId,
    string EmailId) : IRequest<CreateEmployeeResponse>;
