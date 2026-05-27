namespace Practical25.API.Handlers.DeleteEmployee;

public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeRequest>
{
    public DeleteEmployeeValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
