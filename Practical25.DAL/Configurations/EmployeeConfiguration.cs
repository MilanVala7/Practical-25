namespace Practical25.DAL.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.EmailId).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Salary).HasColumnType("decimal(18,2)");
        builder.Property(e => e.Status).HasDefaultValue(true);
        builder.Property(e => e.Notes).HasMaxLength(500);
    }
}
