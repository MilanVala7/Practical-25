using Practical25.DAL.Data;

namespace Practical25.DAL.Repositories;

public class EmployeeQueryRepo(AppDbContext dbContext)
{
    public async Task<Employee?> GetByIdAsync(int? id, CancellationToken cancellationToken)
    {
        return await dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Employees.AsNoTracking().ToListAsync(cancellationToken);
    }
}
