namespace Practical25.DAL.Repositories;

public class EmployeeQueryRepo
{
    private readonly AppDbContext _context;

    public EmployeeQueryRepo(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Employee?> GetByIdAsync(int? id, CancellationToken cancellationToken)
    {
        return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Employees.AsNoTracking().ToListAsync(cancellationToken);
    }
}
