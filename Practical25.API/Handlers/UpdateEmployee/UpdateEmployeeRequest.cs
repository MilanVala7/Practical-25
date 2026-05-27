namespace Practical25.API.Handlers.UpdateEmployee;

public record UpdateEmployeeRequest(
    int Id,
    string Name,
    decimal Salary,
    Department DepartmentId,
    string EmailId) : IRequest<UpdateEmployeeResponse>;
