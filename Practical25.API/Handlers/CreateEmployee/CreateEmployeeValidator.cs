namespace Practical25.API.Handlers.CreateEmployee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
{
    public CreateEmployeeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Salary).GreaterThan(0);
        RuleFor(x => x.DepartmentId).IsInEnum();
        RuleFor(x => x.EmailId).NotEmpty().EmailAddress().MaximumLength(200);
    }
}
