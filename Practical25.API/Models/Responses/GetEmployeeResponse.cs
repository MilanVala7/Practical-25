namespace Practical25.API.Models.Responses;

public record GetEmployeeResponse(
    int Id,
    string Name,
    decimal Salary,
    Department DepartmentId,
    string EmailId,
    DateTime JoiningDate,
    bool Status,
    string? Notes);
