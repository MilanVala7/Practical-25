namespace Practical25.API.Handlers.UpdateEmployee;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Salary).GreaterThan(0);
        RuleFor(x => x.DepartmentId).IsInEnum();
        RuleFor(x => x.EmailId).NotEmpty().EmailAddress().MaximumLength(200);
    }
}
