namespace Practical25.DAL.Repositories;

public class GenericRepo<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _context;

    public GenericRepo(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
