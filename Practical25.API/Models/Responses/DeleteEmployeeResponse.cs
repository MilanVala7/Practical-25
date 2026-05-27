namespace Practical25.API.Models.Responses;

public record DeleteEmployeeResponse(
    int Id,
    bool Status,
    DateTime? DeletedAt,
    DateTime UpdatedAt);
