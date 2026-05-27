using Practical25.DAL.Data;

namespace Practical25.DAL.Repositories;

public class EmployeeCommandRepo(AppDbContext dbContext)
{
    public async Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken)
    {
        dbContext.Employees.Add(employee);
        await dbContext.SaveChangesAsync(cancellationToken);
        return employee;
    }

    public async Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken)
    {
        employee.UpdatedAt = DateTime.UtcNow;
        dbContext.Employees.Update(employee);
        await dbContext.SaveChangesAsync(cancellationToken);
        return employee;
    }

    public async Task<bool> DeleteAsync(Employee employee, CancellationToken cancellationToken)
    {
        employee.Status = false;
        employee.DeletedAt = DateTime.UtcNow;
        employee.UpdatedAt = DateTime.UtcNow;

        dbContext.Employees.Update(employee);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
