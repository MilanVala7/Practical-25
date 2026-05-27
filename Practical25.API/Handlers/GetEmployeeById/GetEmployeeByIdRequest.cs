namespace Practical25.API.Handlers.GetEmployeeById;

public record GetEmployeeByIdRequest(int? Id) : IRequest<GetEmployeeResponse>;
