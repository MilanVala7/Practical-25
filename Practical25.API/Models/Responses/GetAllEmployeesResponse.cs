namespace Practical25.API.Models.Responses;

public record GetAllEmployeesResponse(IReadOnlyCollection<GetEmployeeResponse> Employees);
