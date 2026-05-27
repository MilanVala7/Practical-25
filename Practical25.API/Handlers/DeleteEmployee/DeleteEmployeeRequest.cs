namespace Practical25.API.Handlers.DeleteEmployee;

public record DeleteEmployeeRequest(int Id) : IRequest<DeleteEmployeeResponse>;
