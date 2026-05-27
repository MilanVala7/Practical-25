namespace Practical25.API.Handlers.GetEmployeeById;

public class GetEmployeeByIdValidator : AbstractValidator<GetEmployeeByIdRequest>
{
    public GetEmployeeByIdValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
