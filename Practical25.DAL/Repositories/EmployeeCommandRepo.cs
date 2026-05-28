namespace Practical25.DAL.Repositories;

public class EmployeeCommandRepo
{
    private readonly AppDbContext _context;
    public EmployeeCommandRepo(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Employee> CreateAsync(Employee e, CancellationToken cancellationToken)
    {
        _context.Employees.Add(e);
        await _context.SaveChangesAsync(cancellationToken);
        return e;
    }

    public async Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<Employee> UpdateAsync(Employee e, CancellationToken cancellationToken)
    {
        e.UpdatedAt = DateTime.UtcNow;
        _context.Employees.Update(e);
        await _context.SaveChangesAsync(cancellationToken);
        return e;
    }

    public async Task<bool> DeleteAsync(Employee e, CancellationToken cancellationToken)
    {
        e.Status = false;
        e.DeletedAt = DateTime.UtcNow;
        e.UpdatedAt = DateTime.UtcNow;

        _context.Employees.Update(e);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
