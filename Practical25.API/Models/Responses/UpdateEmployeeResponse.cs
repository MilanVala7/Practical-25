namespace Practical25.API.Models.Responses;

public record UpdateEmployeeResponse(
    int Id,
    string Name,
    decimal Salary,
    Department DepartmentId,
    string EmailId,
    DateTime JoiningDate,
    bool Status);
